using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO.SendInboxMessage;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;
using PSW.GMS.Service.DTO;
using PSW.Lib.Logs;
using System;
using System.IO;
using System.Drawing;
// using IronPdf;
// using IronBarCode;
using System.Linq;
using System.Reflection;
using PSW.GMS.Common.Enums;
using PSW.GMS.Data.Entities;
using System.Collections.Generic;
using System.Text;

namespace PSW.GMS.Service.Helpers
{
    public class FormsTemplate
    {
        /// <summary>
        /// GetFormTemplate
        /// </summary>
        /// <param name="cmd">CommandRequest</param>
        /// <param name="formName">string</param>
        /// <returns>FormTemplates</returns>
        // public static FormTemplates GetFormTemplate(CommandRequest cmd, string formName, int agencyId, string documentTypeCode)
        // {
        //     try
        //     {
        //         Log.Information("[{0}.{1}] Getting Print Template for From Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //         FormTemplates formTemplates = cmd.UnitOfWork.FormTemplatesRepository.Where(new
        //         {
        //             Name = formName,
        //             AgencyID = agencyId,
        //             DocumentTypeCode = documentTypeCode
        //         }).FirstOrDefault();

        //         if (formTemplates == null)
        //         {
        //             Log.Error("[{0}.{1}] Print Template not found From Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //             throw new Exception("Print template not found.");
        //         }

        //         if (!formTemplates.IsActive)
        //         {
        //             Log.Error("[{0}.{1}] Print template is inactive for Form Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //             throw new Exception("Print template is inactive .");
        //         }

        //         Log.Information("[{0}.{1}] Print Template: {@formTemplates}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formTemplates);

        //         return formTemplates;
        //     }
        //     catch (Exception ex)
        //     {
        //         Log.Error("[{0}.{1}] {2}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, ex);
        //         throw ex;
        //     }
        // }

        // public static FormTemplates GetFormTemplateForMFD(CommandRequest cmd, string formName, int agencyId, string documentTypeCode)
        // {
        //     try
        //     {
        //         Log.Information("[{0}.{1}] Getting Print Template for From Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //         FormTemplates formTemplates = cmd.UnitOfWork.FormTemplatesRepository.Where(new
        //         {
        //             Name = formName,
        //             AgencyID = agencyId
        //         }).FirstOrDefault();

        //         if (formTemplates == null)
        //         {
        //             Log.Error("[{0}.{1}] Print Template not found From Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //             throw new Exception("Print template not found.");
        //         }

        //         if (!formTemplates.IsActive)
        //         {
        //             Log.Error("[{0}.{1}] Print template is inactive for Form Name: {@formName}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formName);

        //             throw new Exception("Print template is inactive .");
        //         }

        //         Log.Information("[{0}.{1}] Print Template: {@formTemplates}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, formTemplates);

        //         return formTemplates;
        //     }
        //     catch (Exception ex)
        //     {
        //         Log.Error("[{0}.{1}] {2}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, ex);
        //         throw ex;
        //     }
        // }

        /// <summary>
        /// GetFormNameFromTarp
        /// </summary>
        /// <param name="request">FormNumberRequestDTO</param>
        /// <returns>FormNumberResponseDTO</returns>
        // public FormNumberResponseDTO GetFormNameFromTarp(FormNumberRequestDTO request)
        // {
        //     try
        //     {
        //         var rabbitMqResponse = RabbitMqCallHelper<FormNumberResponseDTO>.SyncCall(request, ServiceMethod.TARP_GET_FORM_NUMBER, MessageQueues.TARPRCQueue);

        //         if (rabbitMqResponse != null)
        //         {
        //             return rabbitMqResponse;
        //         }

        //         return null;
        //     }
        //     catch (Exception ex)
        //     {
        //         Log.Error("[{0}.{1}] {2}", "FormsTemplate", MethodBase.GetCurrentMethod().Name, ex);
        //         throw ex;
        //     }
        // }
    }
}