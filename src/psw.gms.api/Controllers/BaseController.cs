using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW.GMS.Service.Factories;
using PSW.Common.Crypto;
using PSW.GMS.Api.ApiCommand;
using PSW.GMS.Common.Pagination;
using PSW.GMS.Data;
using PSW.GMS.Service;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.Strategies;
using PSW.Lib.Logs;
using psw.common.Extensions;

namespace PSW.GMS.Api.Controllers
{
    public class BaseController : Controller
    {
        #region Properties

        public IService SecureService { get; set; }
        public IService OpenService { get; set; }

        #endregion

        #region Controller

        public BaseController(IGmsSecureService secureService, IGmsOpenService openService, IUnitOfWork uow, ICryptoAlgorithm cryptoAlgorithm, IHttpContextAccessor httpContextAccessor)
        {
            // Dependency Injection of services
            SecureService = secureService;
            SecureService.UnitOfWork = uow;
            SecureService.StrategyFactory = new SecureStrategyFactory(uow);
            SecureService.CryptoAlgorithm = cryptoAlgorithm;

            OpenService = openService;
            OpenService.UnitOfWork = uow;
            OpenService.StrategyFactory = new OpenStrategyFactory(uow);
            OpenService.CryptoAlgorithm = cryptoAlgorithm;

            httpContextAccessor.HttpContext.Request.Headers.TryGetValue("LoggedInUserRoleID", out var userRoleId);
            SecureService.LoggedInUserRoleId = cryptoAlgorithm.Decrypt(userRoleId).ToIntOrDefault();
        }

        #endregion

        #region End Points 

        // TODO: Authentication
        // Assuming Request is Authenticated.
        [HttpPost("secure")]
        //[Authorize("authorizedUserPolicy")]
        public virtual ActionResult<APIResponse> SecureRequest(APIRequest apiRequest)
        {
            //TODO: Client Id Authentication here
            var apiResponse = new APIResponse
            {
                methodId = apiRequest.methodId,
                message = new ResponseMessage
                {
                    code = "404",
                    description = "Action not found."
                },
                //TODO: Add error object if required
                error = new ErrorModel(),
                //TODO: Add pagination if required
                pagination = new ServerPaginationModel()
            };

            try
            {
                //TODO: Resource Authorization (Middleware)
                //TODO: Pass User Details and Method ID to Middleware for Action/Method/Resource Authorization

                // Assuming Request is Authenticated
                // Crate JsonElement for service
                // Calling Service 
                CommandReply commandReply = SecureService.invokeMethod(
                    new CommandRequest
                    {
                        methodId = apiRequest.methodId,
                        data = apiRequest.data,
                        CurrentUser = HttpContext.User,
                        UserClaims = HttpContext.User.Claims,
                        pagination = apiRequest.pagination,
                        LoggedInUserRoleID = SecureService.LoggedInUserRoleId,
                    }
                );

                // Preparing Response 
                apiResponse = ApiResponseByCommand(commandReply, apiResponse);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception caught: {ex.ToString()}");

                // Prepare Appropriate Response
                apiResponse.message.code = "404";
                apiResponse.message.description = "Error : " + ex.Message;
            }
            finally
            {
                SecureService?.UnitOfWork?.CloseConnection();
            }

            // Send Response 
            return apiResponse;
        }

        [HttpPost("open")]
        public virtual ActionResult<object> OpenRequest(APIRequest apiRequest)
        {
            var apiResponse = new APIResponse
            {
                methodId = apiRequest.methodId,
                message = new ResponseMessage()
            };

            try
            {
                //TODO: Resource Authorization (Middleware)
                //TODO: Pass User Details and Method ID to Middleware for Action/Method/Resource Authorization

                // Assuming Request is Authenticated
                // Calling Service 
                CommandReply commandReply = OpenService.invokeMethod(
                    new CommandRequest
                    {
                        methodId = apiRequest.methodId,
                        data = apiRequest.data
                    }
                );

                // Preparing Response 
                apiResponse = ApiResponseByCommand(commandReply, apiResponse);
            }
            catch (Exception ex)
            {
                // Prepare Appropriate Response
                apiResponse.message.code = "404";
                apiResponse.message.description = "Error : " + ex.Message;
            }
            finally
            {
                SecureService?.UnitOfWork?.CloseConnection();
            }

            // Send Response 
            return apiResponse;
        }

        [HttpGet("query/{methodId}")]
        public virtual ActionResult<object> OpenRequest(string methodId, string username, int duration)
        {
            //TODO: Client Id Authentication here
            var apiResponse = new APIResponse
            {
                methodId = methodId,
                message = new ResponseMessage
                {
                    code = "404",
                    description = "Action not found."
                },
                //TODO: Add error object if required
                error = null,
                //TODO: Add pagination if required
                pagination = null
            };

            try
            {
                //TODO: Resource Authorization (Middleware)
                //TODO: Pass User Details and Method ID to Middleware for Action/Method/Resource Authorization

                // Assuming Request is Authenticated
                // Crate JsonElement for service
                string json = "{" + $@"""username"":""{username}"",""duration"":{duration}" + "}";
                JsonElement element = JsonDocument.Parse(json).RootElement;

                // Calling Service 
                CommandReply commandReply = OpenService.invokeMethod(
                    new CommandRequest
                    {
                        methodId = methodId,
                        data = element
                    }
                );

                // Preparing Response
                apiResponse.data = commandReply.data;
                apiResponse.message.code = commandReply.code;
                apiResponse.message.description = commandReply.message;

                // Sign Data
                string signature = Sign(commandReply.data);
                apiResponse.signature = signature;
            }
            catch (Exception ex)
            {
                // Prepare Appropriate Response 
                apiResponse.message.code = "404";
                apiResponse.message.description = "Error : " + ex.Message;
            }

            // Send Response 
            return apiResponse;
        }

        [HttpGet("version")]
        public virtual ActionResult<object> GetVersion()
        {
            return "20210208_081653";
        }

        #endregion

        #region Helper Methods 

        protected string Sign(JsonElement data)
        {
            // TODO Call Sign API to Get Signature  
            using HashAlgorithm algorithm = SHA256.Create();
            return Convert.ToBase64String(algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data.ToString() ?? string.Empty)));
        }

        protected APIResponse ApiResponseByCommand(CommandReply commandReply, APIResponse apiResponse)
        {
            try
            {
                apiResponse.data = commandReply.data; // TODO: Safe Check on Data
                string signature = Sign(commandReply.data); // TODO: Safe Check Data
                apiResponse.signature = signature; // Sign Data 

                apiResponse.message.code = string.IsNullOrEmpty(commandReply.code) ? "400" : commandReply.code;
                apiResponse.message.description = string.IsNullOrEmpty(commandReply.message) ? "Bad Request" : commandReply.message;

                if (apiResponse.error != null)
                {
                    apiResponse.error.exception = string.IsNullOrEmpty(commandReply.exception) ? "" : commandReply.exception;
                    apiResponse.error.shortDescription = string.IsNullOrEmpty(commandReply.shortDescription) ? "" : commandReply.shortDescription;
                    apiResponse.error.fullDescription = string.IsNullOrEmpty(commandReply.fullDescription) ? "" : commandReply.fullDescription;
                }
                if (apiResponse.pagination != null)
                {
                    apiResponse.pagination = commandReply.pagination;
                }


            }
            catch (Exception ex)
            {
                apiResponse.message.code = "400";
                apiResponse.message.description = "Cannot Prepare Response";
                if (apiResponse.error != null) apiResponse.error.exception = "Exception : " + ex;
            }

            return apiResponse;

        }

        public virtual async Task<FileStreamResult> ReturnDisputedRecordsFileStream(string filePath)
        {
            byte[] result;
            using (FileStream SourceStream = System.IO.File.Open(filePath, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length).ConfigureAwait(false);
            }
            Stream stream = new MemoryStream(result);
            //filePath = Path.GetFileName(filePath);
            FileStreamResult fs = new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "FileName"
            };

            System.IO.File.Delete(filePath);
            Log.Information($"ReturnDisputedRecordsFileStream | returning stream");
            return fs;
        }

        [HttpPost("fileRegistration")]
        //public virtual ActionResult<APIResponse> FileRegistration([FromForm] APIRequestFileRegistration apiRequest)
        public virtual async Task<IActionResult> FileRegistration([FromForm] APIRequestFileRegistration apiRequest)
        {
            string path = "";
            var apiResponse = new APIResponse
            {
                methodId = apiRequest.methodId,
                message = new ResponseMessage
                {
                    code = "404",
                    description = "Action not found."
                },
                //TODO: Add error object if required
                error = new ErrorModel(),
                //TODO: Add pagination if required
                pagination = new ServerPaginationModel()
            };
            try
            {
                PSW.GMS.Api.ApiCommand.Data data = new PSW.GMS.Api.ApiCommand.Data
                {
                    filepath = apiRequest.FilePath,
                    documentClassificationCode = apiRequest.DocumentClassificationCode,
                    requestDocumentTypeCode = apiRequest.RequestDocumentTypeCode,
                    agencyID = apiRequest.AgencyID,
                    fileId = apiRequest.fileId,
                    roleCode = apiRequest.roleCode
                };
                //TODO: Resourse Authorization (Middleware)
                //TODO: Pass User Detials and Method ID to Middleware for Action/Method/Resourse Authorization
                // Assuming Request is Authenticated 
                // bool authenticated = true;
                // if (authenticated)
                // {
                // Calling Service 
                CommandReply commandReply = SecureService.invokeMethod(
                new CommandRequest()
                {
                    methodId = apiRequest.methodId,
                    data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(data)).RootElement,
                    CurrentUser = HttpContext.User,
                    UserClaims = HttpContext.User.Claims,
                    pagination = apiRequest.pagination,
                    file = apiRequest.file,
                    roleCode = apiRequest.roleCode
                });
                Log.Information($"|FileRegistration| Path {path}.");
                if (commandReply.code == "400" || commandReply.code == "500")
                {
                    return BadRequest(commandReply.message);
                }
                path = commandReply.message;
                Log.Information($"|FileRegistration| Path {path}.");

                // if (String.IsNullOrEmpty(path))
                // {
                //     throw new Exception("Something went wrong, File Not Uploaded!");
                // }
                if (System.IO.File.Exists(path))
                {
                    return await ReturnDisputedRecordsFileStream(path);
                }
                //if no disputed records found..
                return Ok();

                // Write a function to do this 
                // Preparing Resposnse 

                // apiResponse.data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(data)).RootElement;//commandReply.data;
                // apiResponse.message.code = commandReply.code;
                // apiResponse.message.description = commandReply.message;
                // //   -- Sign Data 
                // string signature = Sign(commandReply.data);
                // apiResponse.signature = signature;
                // }
                // else
                // {
                // apiResponse.message.code = "404";
                // apiResponse.message.description = "Not Authorized";
                //}

            }
            catch (Exception ex)
            {
                Log.Error($"BaseController {ex.ToString()}");
                return BadRequest(ex.Message);
            }
            // catch (ServiceException ex)
            // {
            //     // Log 
            //     //  _logger.Log(ex.Message);
            //     // // Prepare Appropriate Response 
            //     apiResponse.message.code = "404";
            //     apiResponse.message.message = "Error : " + ex.Message;
            //     // throw;
            // }

            // Log 
            // _logger.Log("Sending This Response");


            //return apiResponse;
        }

        [HttpPost("uploadFile")]
        //public virtual ActionResult<APIResponse> FileRegistration([FromForm] APIRequestFileRegistration apiRequest)
        public virtual async Task<ActionResult<APIResponse>> UploadFile([FromForm] APIRequestFileRegistration apiRequest)
        {
            string path = "";
            var apiResponse = new APIResponse
            {
                methodId = apiRequest.methodId,
                message = new ResponseMessage
                {
                    code = "404",
                    description = "Action not found."
                },
                //TODO: Add error object if required
                error = new ErrorModel(),
                //TODO: Add pagination if required
                pagination = new ServerPaginationModel()
            };
            try
            {
                PSW.GMS.Api.ApiCommand.Data data = new PSW.GMS.Api.ApiCommand.Data
                {
                    filepath = apiRequest.FilePath,
                    documentClassificationCode = apiRequest.DocumentClassificationCode,
                    requestDocumentTypeCode = apiRequest.RequestDocumentTypeCode,
                    agencyID = apiRequest.AgencyID,
                    fileId = apiRequest.fileId,
                    roleCode = apiRequest.roleCode
                };

                // Calling Service 
                CommandReply commandReply = SecureService.invokeMethod(
                new CommandRequest()
                {
                    methodId = apiRequest.methodId,
                    data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(data)).RootElement,
                    CurrentUser = HttpContext.User,
                    UserClaims = HttpContext.User.Claims,
                    pagination = apiRequest.pagination,
                    file = apiRequest.file,
                    roleCode = apiRequest.roleCode
                });
                Log.Information($"|uploadFile| Path {path}.");
                if (commandReply.code == "400" || commandReply.code == "500")
                {
                    return BadRequest(commandReply.message);
                }
                path = commandReply.message;
                apiResponse.data = commandReply.data;
                Log.Information($"|uploadFile| Path {path}.");

                if (System.IO.File.Exists(path))
                {
                    return await ReturnDisputedRecordsFileStream(path);
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error($"BaseController.uploadFile {ex.ToString()}");
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}