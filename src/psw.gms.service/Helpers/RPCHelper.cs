using System;
using System.Reflection;
using System.Text.Json;
using PSW.Lib.Logs;
using PSW.RabbitMq;
using PSW.RabbitMq.RPC;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;

namespace PSW.GMS.Service.Helpers
{
    public class RPCHelper
    {
        public ServiceReply GetInformation(ServiceRequest serviceRequest, string remoteQueue)
        {
            var rpcClient = new RPCClient(remoteQueue);
            try
            {
                Log.Information("[{0}.{1}] RabbitMq Request to {2} : {@serviceRequest}", "RPCHelper", MethodBase.GetCurrentMethod().Name, remoteQueue, serviceRequest);

                var rabbitMQResponse = rpcClient.CallAsync(serviceRequest, remoteQueue).Result;
                var serviceReply = (ServiceReply)RabbitMqHelper.ByteArrayToObject(rabbitMQResponse);

                Log.Information("[{0}.{1}] RabbitMq Response from {2} : {@serviceReply}", "RPCHelper", MethodBase.GetCurrentMethod().Name, remoteQueue, serviceReply);

                return serviceReply;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rpcClient.Close();
            }
        }
        public T GetInformation<T>(ServiceRequest serviceRequest, string remoteQueue)
        {
            var rpcClient = new RPCClient(remoteQueue);
            try
            {
                Log.Information("[{0}.{1}] RabbitMq Request to {2} : {@serviceRequest}", "RPCHelper", MethodBase.GetCurrentMethod().Name, remoteQueue, serviceRequest);

                var rabbitMQResponse = rpcClient.CallAsync(serviceRequest, remoteQueue).Result;
                var responseBytes = (ServiceReply)RabbitMqHelper.ByteArrayToObject(rabbitMQResponse);
                if (responseBytes != null && responseBytes.data != null)
                {
                    var response = JsonSerializer.Deserialize<T>(responseBytes.data);
                    Log.Information("[{0}.{1}] RabbitMq Response from {2} : {@response}", "RPCHelper", MethodBase.GetCurrentMethod().Name, remoteQueue, response);
                    return response;
                }

                Log.Information("[{0}.{1}] RabbitMq Response from {2} : Null", "RPCHelper", MethodBase.GetCurrentMethod().Name, remoteQueue);

                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rpcClient.Close();
            }
        }
    }
}