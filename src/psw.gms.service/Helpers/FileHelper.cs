using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.GMS.Service.DTO;
using System.Collections.Generic;
using System.Reflection;
using PSW.Lib.Logs;
using PSW.GMS.Common;
using System.Net;

namespace PSW.GMS.Service.Helpers
{
    public static class FileHelper
    {
        public static GetFilesDetailResponseDTO GetFilesDetails(CommandRequest cmd, List<string> files)
        {
            var requestDto = new GetFilesDetailRequestDTO
            {
                Files = files
            };

            var svcRequest = new ServiceRequest
            {
                methodId = Constant.GetFileDetails,
                data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(requestDto)).RootElement.GetRawText()
            };

            Log.Information("[{0}.{1}] RabbitMq Request to {2}: {@svcRequest}", "FileHelper", MethodBase.GetCurrentMethod().Name, MessageQueues.FSSRPCQueue, svcRequest);

            var rabbitMQResponse = new RPCHelper().GetInformation(svcRequest, MessageQueues.FSSRPCQueue);

            Log.Information("[{0}.{1}] RabbitMq Response from {2}: {@rabbitMQResponse}", "FileHelper", MethodBase.GetCurrentMethod().Name, MessageQueues.FSSRPCQueue, rabbitMQResponse);

            if (rabbitMQResponse?.data != null)
            {
                var response = JsonSerializer.Deserialize<GetFilesDetailResponseDTO>(rabbitMQResponse.data);
                return response;
            }

            return null;
        }

        public static GetFileBytesResponseDTO GetFileBytes(CommandRequest cmd, long fid)
        {
            var requestDto = new GetFileBytesRequestDTO
            {
                FileId = fid
            };

            var svcRequest = new ServiceRequest
            {
                methodId = Constant.GetFileBytes,
                data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(requestDto)).RootElement.GetRawText()
            };

            Log.Information("[{0}.{1}] RabbitMq Request to {2}: {@svcRequest}", "FileHelper", MethodBase.GetCurrentMethod().Name, MessageQueues.FSSRPCQueue, svcRequest);

            var rabbitMQResponse = new RPCHelper().GetInformation(svcRequest, MessageQueues.FSSRPCQueue);

            Log.Information("[{0}.{1}] RabbitMq Response from {2}: {@rabbitMQResponse}", "FileHelper", MethodBase.GetCurrentMethod().Name, MessageQueues.FSSRPCQueue, rabbitMQResponse);

            if (rabbitMQResponse?.data != null && rabbitMQResponse.code == ((int)HttpStatusCode.OK).ToString())
            {
                var response = JsonSerializer.Deserialize<GetFileBytesResponseDTO>(rabbitMQResponse.data);
                return response;
            }

            return null;
        }
    }
}