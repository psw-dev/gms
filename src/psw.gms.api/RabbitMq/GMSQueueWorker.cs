using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using PSW.RabbitMq;
using PSW.RabbitMq.Task;
using PSW.RabbitMq.ServiceCommand;
using System;
using PSW.GMS.Service;
using Microsoft.Extensions.Configuration;
using PSW.Common.Crypto;
using PSW.GMS.Service.Command;
using System.Text.Json;
using PSW.GMS.Data.Sql;
using PSW.GMS.Service.Strategies;
using AutoMapper;
using System.Security.Cryptography;
using PSW.Lib.Logs;

/// <summary>
///     GMSQueueWorker
/// </summary>
public class GMSQueueWorker : AsyncWorker, IHostedService
{

    #region Field
    private Task _executingTask;
    private CancellationTokenSource _cts;
    private IGmsSecureService _service { get; set; }
    private IConfiguration _configuration;
    private ICryptoAlgorithm _cryptoAlgorithm { get; set; }
    private IMapper _mapper { get; set; }

    #endregion

    #region Constructor

    public GMSQueueWorker(IConfiguration configuration, IMapper mapper)
    {
        this._configuration = configuration;
        _mapper = mapper;
    }

    #endregion

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _executingTask = ExecuteAsync(cancellationToken);
        if (_executingTask.IsCompleted)
        {
            return _executingTask;
        }
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

        if (_executingTask == null)
        {
            return;
        }
        try
        {
            _cts.Cancel();
            this.Stop();
        }
        finally
        {
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }
    protected Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            // this.Start(MessageQueues.GMSTask); 
        });
    }

    /// <summary>
    ///  ProcessMessage
    /// </summary>
    /// <param name="svcRequest"></param>
    /// <returns></returns>
    public override ServiceReply ProcessMessage(ServiceRequest svcRequest)
    {
        //TODO: Invoke method
        System.Console.WriteLine("SERVICE RECIEVED");
        string salt = Environment.GetEnvironmentVariable("ENCRYPTION_SALT");
        string password = Environment.GetEnvironmentVariable("ENCRYPTION_PASSWORD");
        _cryptoAlgorithm = new CryptoFactory().Create<AesManaged>(password, salt);
        System.Console.WriteLine("SERVICE RECIEVED");
        Log.Information("GMSQueueWorker.ProcessMessage received request {@svcRequest}. Method Id: {0}", svcRequest, svcRequest.methodId);

        var cmdRequest = new CommandRequest()
        {
            methodId = svcRequest.methodId,
            data = JsonDocument.Parse(svcRequest.data).RootElement,
            CryptoAlgorithm = _cryptoAlgorithm
        };

        _service = new GmsSecureService(_mapper, _cryptoAlgorithm);
        _service.UnitOfWork = new UnitOfWork(_configuration);
        _service.StrategyFactory = new SecureStrategyFactory(_service.UnitOfWork);

        ServiceReply svcReply = null;
        try
        {
            var commandReply = _service.Invoke(cmdRequest);

            svcReply = new ServiceReply()
            {
                data = commandReply.data.GetRawText(),
                code = commandReply.code,
                exception = commandReply.exception,
                shortDescription = commandReply.shortDescription,
                fullDescription = commandReply.fullDescription,
                message = commandReply.message
            };
        }
        catch (Exception exception)
        {
            Log.Error(exception, "Fail to Process message  {ServiceRequest} | Exception {Exception}", svcRequest, exception.ToString());
            svcReply = new ServiceReply()
            {
                data = string.Empty,
                code = "500",
                exception = exception.ToString(),
                fullDescription = string.Empty,
                message = "Error occured"
            };
        }

        return svcReply;
    }
}