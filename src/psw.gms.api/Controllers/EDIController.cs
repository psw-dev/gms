using Microsoft.AspNetCore.Mvc;
using PSW.GMS.Api.ApiCommand;
using PSW.GMS.Service;
using PSW.GMS.Data;
using Microsoft.AspNetCore.Authorization;
using PSW.Common.Crypto;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.Strategies;
using PSW.GMS.Service.Factories;
using PSW.GMS.Common.Pagination;
using PSW.GMS.Service.Command;
using System;
using PSW.Lib.Logs;
using System.Text.Json;
using System.Security.Cryptography;
// using PSW.GMS.Api.IPCLogging;
using PSW.GMS.Common.Constants;

namespace PSW.GMS.Api.Controllers
{
    [Route("api/v1/gms/[controller]")]
    [ApiController]
    public class EDIController : Controller
    {
        #region Properties

        public IService SecureService { get; set; }
        public IService OpenService { get; set; }

        // public IPCLog AuditLog { get; set; }

        #endregion

        #region Constructors

        public EDIController(IGmsSecureService secureService, IGmsOpenService openService, IUnitOfWork uow, ICryptoAlgorithm cryptoAlgorithm)
        {
            SecureService = secureService;
            SecureService.UnitOfWork = uow;
            SecureService.StrategyFactory = new SecureStrategyFactory(uow);
            SecureService.CryptoAlgorithm = cryptoAlgorithm;

            OpenService = openService;
            OpenService.UnitOfWork = uow;
            OpenService.StrategyFactory = new OpenStrategyFactory(uow);
            OpenService.CryptoAlgorithm = cryptoAlgorithm;
        }

        #endregion

        #region End Points 

        [HttpPost("secure")]
        // [Authorize("authGMSPolicy")]
        public ActionResult<EDIResponse> SecureRequest(EDIRequest ediRequest)
        {

            //Create IPC Log Instance
            // IPCLog auditLog = IPCLogInstance.CreateIPCLogInstance(this.SecureService.UnitOfWork, ediRequest);

            //TODO: Client Id Authentication here
            var ediResponse = new EDIResponse
            {
                methodId = ediRequest.methodId,
                message = new ResponseMessage
                {
                    code = "404",
                    description = "Action not found."
                },
                //TODO: Add error object if required
                error = new ErrorModel(),
                //TODO: Add pagination if required
                pagination = new ServerPaginationModel(),

                messageId = ediRequest.messageId,
                timestamp = ediRequest.timestamp,
                //sender and receiver will get interchanged
                senderId = ediRequest.receiverId,
                receiverId = ediRequest.senderId
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
                        methodId = ediRequest.methodId,
                        data = ediRequest.data,
                        CurrentUser = HttpContext.User,
                        UserClaims = HttpContext.User.Claims,
                        pagination = ediRequest.pagination,
                        // AuditLog = auditLog
                    }
                );

                // Preparing Response 
                ediResponse = ApiResponseByCommand(commandReply, ediResponse);

                // Audit Log
                // auditLog.Status = IPCLogStatus.Success;
                if (!commandReply.code.Equals("200"))
                {
                    // auditLog.Status = IPCLogStatus.Failed;
                }

                // auditLog.ResponsePayLoad = JsonSerializer.Serialize(ediResponse);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception caught: {ex.ToString()}");

                // Prepare Appropriate Response
                ediResponse.message.code = "404";
                ediResponse.message.description = "Error : " + ex.Message;

                // auditLog.ResponsePayLoad = JsonSerializer.Serialize(ediResponse);
                // auditLog.Status = IPCLogStatus.Failed;
            }
            finally
            {
                // auditLog.ResponsePayLoad = auditLog.ResponsePayLoad;
                // this.SecureService.UnitOfWork.IPCLogRepository.Update(auditLog);
                // IPCLogInstance.LogIPCResponse(this.SecureService.UnitOfWork, AuditLog.ResponsePayLoad, AuditLog.ID, AuditLog.Status, AuditLog);
                this.SecureService?.UnitOfWork?.CloseConnection();
            }

            // Send Response 
            return ediResponse;
        }

        protected EDIResponse ApiResponseByCommand(CommandReply commandReply, EDIResponse ediResponse)
        {
            try
            {
                ediResponse.data = commandReply.data; // TODO: Safe Check on Data
                string signature = Sign(commandReply.data); // TODO: Safe Check Data
                ediResponse.signature = signature; // Sign Data 

                ediResponse.message.code = string.IsNullOrEmpty(commandReply.code) ? "400" : commandReply.code;
                ediResponse.message.description = string.IsNullOrEmpty(commandReply.message) ? "Bad Request" : commandReply.message;

                if (ediResponse.error != null)
                {
                    ediResponse.error.exception = string.IsNullOrEmpty(commandReply.exception) ? "" : commandReply.exception;
                    ediResponse.error.shortDescription = string.IsNullOrEmpty(commandReply.shortDescription) ? "" : commandReply.shortDescription;
                    ediResponse.error.fullDescription = string.IsNullOrEmpty(commandReply.fullDescription) ? "" : commandReply.fullDescription;
                }
                if (ediResponse.pagination != null)
                {
                    ediResponse.pagination = commandReply.pagination;
                }
            }
            catch (Exception ex)
            {
                ediResponse.message.code = "400";
                ediResponse.message.description = "Cannot Prepare Response";
                if (ediResponse.error != null) ediResponse.error.exception = "Exception : " + ex;
            }

            return ediResponse;

        }

        protected string Sign(JsonElement data)
        {
            // TODO Call Sign API to Get Signature  
            using HashAlgorithm algorithm = SHA256.Create();
            return Convert.ToBase64String(algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data.ToString() ?? string.Empty)));
        }

        [HttpGet("env")]
        public ActionResult<object> GetEnv()
        {
            return System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        #endregion
    }
}