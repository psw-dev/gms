using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO.SendInboxMessage;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;

namespace PSW.GMS.Service.Helpers
{
    public class Messenger
    {
        /// <summary>
        ///     This method is used to publish message on INBOX queue
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="requestDto"></param>
        public static void SendMessage(CommandRequest cmd, SendInboxMessageRequestDTO requestDto)
        {
            var eventQueue = new AsyncTask(MessageQueues.InboxTask);
            var svcRequest = new ServiceRequest
            {
                methodId = Constant.SendInboxMessageMethodId,
                data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(requestDto)).RootElement.GetRawText()
            };

            // Async communication with ANS using Fire and Forget pattern
            // cmd.UnitOfWork.eventBus.PublishRequest(svcRequest, MessageQueues.InboxTask);
            eventQueue.Execute(svcRequest);
        }
    }
}
