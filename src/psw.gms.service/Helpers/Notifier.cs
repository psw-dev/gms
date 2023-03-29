using System.Text.Json;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;

namespace PSW.GMS.Service.Helpers
{
    public class Notifier
    {
        /// <summary>
        ///     This method is used to publish message on ANS queue
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="methodId"></param>
        /// <param name="requestDTO"></param>
        public static void SendNotification(CommandRequest cmd, string methodId, NotificationRequestDTO requestDTO)
        {
            //Service Request Creation
            var publishQueue = new AsyncTask(MessageQueues.ANSTask);
            var svcRequest = new ServiceRequest()
            {
                methodId = methodId,
                data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(requestDTO)).RootElement.GetRawText()
            };

            // Async communication with ANS using Fire and Forget pattern
            //cmd.UnitOfWork.eventBus.PublishRequest(svcRequest, MessageQueues.ANSTask);
            publishQueue.Execute(svcRequest);
        }
    }
}