using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PSW.Common.Crypto;
using PSW.Lib.Logs;
using PSW.GMS.Data;
using PSW.GMS.Data.Sql;
using PSW.GMS.Service;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.Strategies;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;

namespace PSW.GMS.RabbitMq
{
    public class GMSRabbitMqListener : RabbitMqListener
    {
        private IGmsSecureService SecureService { get; set; }

        public GMSRabbitMqListener(IGmsSecureService secureService, IUnitOfWork uow, IConfiguration configuration)
        : base(configuration)
        {
            this.SecureService = secureService;
            this.SecureService.UnitOfWork = uow;
            this.SecureService.StrategyFactory = new SecureStrategyFactory(uow);
        }

        public override void ProcessMessage(ServiceRequest request, IConfiguration configuration, IEventBus eventBus, string correlationId, string replyTo)
        {
            Log.Information("GMSRabbitMqListener.ProcessMessage received request {@request}. Method Id: {0}", request, request.methodId);
            SecureService.UnitOfWork = new UnitOfWork(configuration, eventBus);

            //Adding ServiceRequest data to CommandRequest and
            // invoking service method
            var commandReply = SecureService.invokeMethod(new CommandRequest()
            {
                methodId = request.methodId,
                data = JsonDocument.Parse(request.data).RootElement
            });

            //Checking if there is a need to reply back after processing request
            if (string.IsNullOrEmpty(correlationId))
            {
                return;
            }

            //Adding CommandReply data to ServiceReply and
            //publishing reply to provided queue name in replyTo
            eventBus.PublishReply(new ServiceReply()
            {
                code = commandReply.code,
                data = commandReply.data.GetRawText(),
                shortDescription = commandReply.shortDescription,
                fullDescription = commandReply.fullDescription,
                message = commandReply.message,
                exception = commandReply.exception
            }, replyTo, correlationId);
        }
    }
}
