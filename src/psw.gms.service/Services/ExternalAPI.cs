using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using RestSharp;
using Serilog;

namespace PSW.GMS.Service.Services
{
    public static class ExternalAPI
    {
        //     public static string APICall(string requestJson, string apiUrl, string bearerToken, string callingClass = "", string callingMethod = "")
        //     {
        //         try
        //         {
        //             Log.Information("[{0}.{1}] {2}", callingClass, callingMethod, $"request: {requestJson}");
        //             var client = new RestClient(apiUrl) { Timeout = -1 };
        //             var request = new RestRequest(Method.POST);



        //             if (!string.IsNullOrEmpty(bearerToken))
        //                 request.AddHeader("Authorization", $"Bearer {bearerToken}");

        //             request.AddHeader("Content-Type", "application/json");
        //             request.AddParameter("application/json", requestJson, ParameterType.RequestBody);
        //             var response = client.Execute(request);
        //             var responseContent = response.Content;
        //             Log.Information("[{0}.{1}] {2}", callingClass, callingMethod, $"response: {responseContent}");
        //             return responseContent;
        //         }
        //         catch (Exception e)
        //         {
        //             Console.WriteLine(e);
        //             throw;
        //         }
        //     }
        // }

        public static string APICall(string requestJson, string apiUrl, string bearerToken, string callingClass = "", string callingMethod = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            var webocResponseObj = "";

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                var uriBuilder = new UriBuilder(apiUrl);

                Log.Information("Sending request to Weboc --> {@RequestDTO}", requestJson);
                var request = requestJson;
                var payload = new StringContent(request, Encoding.UTF8, "application/json");
                var result = string.Empty;

                //AUDITID = IPCLogUtility.IPCLog(unitOfWork, request, uriBuilder.Uri.ToString(), methodId);

                //var AuditLog = new IPCLog();
                // AuditLog.ID = AUDITID;

                try
                {
                    Log.Information($"|ExternalCallManager|RequestToWeboc| Payload: {request}");
                    result = client.PostAsync(uriBuilder.Uri, payload).Result.Content.ReadAsStringAsync().Result;
                    webocResponseObj = result;
                    Log.Information("Received response from Weboc <-- {@RequestDTO}", webocResponseObj);

                    // if (webocResponseObj.Code.ToString() != WebocResponseCode.SUCCESS)
                    // {
                    //     AuditLog.Status = IPCLogStatus.Failed;
                    //     AuditLog.ResponsePayLoad = result.Replace("'", "\"");
                    // }
                    // else
                    // {
                    //     AuditLog.Status = IPCLogStatus.Success;
                    //     AuditLog.ResponsePayLoad = result;
                    // }
                }
                catch (Exception ex)
                {
                    // AuditLog.Status = IPCLogStatus.Failed;
                    //AuditLog.ResponsePayLoad = result;
                    Log.Error($"|ExternalCallManager|RequestToWeboc| Error: {ex.ToString()}");
                }
                finally
                {
                    //IPCLogUtility.LogIPCResponse(unitOfWork, AuditLog.ResponsePayLoad, AuditLog.ID, AuditLog.Status);
                }
                return webocResponseObj;
            }
        }

        public static string APICallWeBocRegistration(string requestJson, string apiUrl, string bearerToken, string callingClass = "", string callingMethod = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            var webocResponseObj = "";

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                var uriBuilder = new UriBuilder(apiUrl);

                Log.Information("Sending request to Weboc --> {@RequestDTO}", requestJson);
                var request = requestJson;
                var payload = new StringContent(request, Encoding.UTF8, "application/json");
                var result = string.Empty;

                //AUDITID = IPCLogUtility.IPCLog(unitOfWork, request, uriBuilder.Uri.ToString(), methodId);

                //var AuditLog = new IPCLog();
                // AuditLog.ID = AUDITID;

                try
                {
                    Log.Information($"|ExternalCallManager|RequestToWeboc| Payload: {request}");
                    result = client.PostAsync(uriBuilder.Uri, payload).Result.Content.ReadAsStringAsync().Result;
                    webocResponseObj = result;
                    Log.Information("Received response from Weboc <-- {@RequestDTO}", webocResponseObj);

                    // if (webocResponseObj.Code.ToString() != WebocResponseCode.SUCCESS)
                    // {
                    //     AuditLog.Status = IPCLogStatus.Failed;
                    //     AuditLog.ResponsePayLoad = result.Replace("'", "\"");
                    // }
                    // else
                    // {
                    //     AuditLog.Status = IPCLogStatus.Success;
                    //     AuditLog.ResponsePayLoad = result;
                    // }
                }
                catch (Exception ex)
                {
                    // AuditLog.Status = IPCLogStatus.Failed;
                    //AuditLog.ResponsePayLoad = result;
                    Log.Error($"|ExternalCallManager|RequestToWeboc| Error: {ex.ToString()}");
                    throw;
                }
                finally
                {
                    //IPCLogUtility.LogIPCResponse(unitOfWork, AuditLog.ResponsePayLoad, AuditLog.ID, AuditLog.Status);
                }
                return webocResponseObj;
            }
        }
    }
}