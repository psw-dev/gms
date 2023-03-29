using AutoMapper;
using PSW.GMS.Service.DTO.EDI;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.Helpers;
using PSW.Security.Signature;
using System;
using System.Linq;
using System.Text.Json;

namespace PSW.GMS.Service.Managers
{
    public static class WokerJobManager
    {

        /// <summary>
        /// AddJobForAD- add record in ADWokerJob table, so the woker service will 
        /// fetch records from db and try to send http calls to designatied AD
        /// </summary>
        /// <param name="cmd">cmd</param>
        /// <param name="requestPayload">requestPayload</param>
        /// <param name="methodId">methodId</param>
        /// <param name="receivingAgency">receivingAgency</param>
        /// <param name="url">url</param>
        public static void addJobForEDI(CommandRequest cmd, Object requestPayload, string processingCode, string receivingAgency, string url)
        {
            try
            {
                AppConfig workerConfig = new AppConfig();
                var config = cmd.UnitOfWork.AppConfigRepository.Get(EDIWokerConfig.GMSWorkerMaxRetryAttempts);

                if (config == null)
                {
                    workerConfig.Value = EDIWokerConfig.DefaultGMSWorkerMaxRetryAttempts;
                }
                else
                {
                    workerConfig = config;
                }

                //var url = bankConfigInfo.MessageURL;
                //Log.Information("Bank URL: " + url);

                JsonMessageSignature messageSignature = new JsonMessageSignature();

                var message = new ThirdPartyRequestDTO();
                message.messageId = Guid.NewGuid().ToString();
                message.timeStamp = DateTime.Now;
                message.senderId = EDIAgencyConstants.PSW;
                message.receiverId = receivingAgency;
                message.methodId = processingCode;
                message.data = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(requestPayload)).RootElement;
                message.signature = messageSignature.Sign(message.data);

                string jsonString = JsonSerializer.Serialize(message);

                // WorkerJobs request = new WorkerJobs()
                // {
                //     SourceCode = EDIAgencyConstants.PSW,
                //     DestinationCode = receivingAgency,
                //     SourceEndpoint = EDIAgencyConstants.PSW,
                //     DestinationEndpoint = url,
                //     RequestPayLoad = jsonString,
                //     ResponsePayLoad = "",
                //     MethodID = processingCode,
                //     WorkerJobStatusID = 0,
                //     Attempts = 0,
                //     RemainingAttempts = Convert.ToInt32(workerConfig.Value),
                //     CreatedOn = DateTime.Now,
                //     UpdatedOn = DateTime.Now
                // };

                // cmd.UnitOfWork.WorkerJobsRepository.Add(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}