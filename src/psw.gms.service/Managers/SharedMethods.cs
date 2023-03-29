// using PSW.GMS.Service.DTO.EDI;
using PSW.GMS.Service.Helpers;
using PSW.Lib.Logs;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.Command;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace PSW.GMS.Service.Managers
{
    public static class SharedMethods
    {
        // public static void UpdateRelaeaseOrderStatus(CommandRequest command, PSW.GMS.Data.Entities.ReleaseOrder releaseOrder, int status)
        // {
        //     // TODO: Implement Bulk Insert here
        //     // Maintain Export Certificate Status Change Record History
        //     releaseOrder.ReleaseOrderStatusID = (short)status;
        //     releaseOrder.UpdatedOn = DateTime.Now;

        //     command.UnitOfWork.ReleaseOrderRepository.Update(releaseOrder);
        // }

        // public static void UpdateExportCertificateStatus(CommandRequest command, PSW.GMS.Data.Entities.ExportCertificate ec, int status)
        // {
        //     // TODO: Implement Bulk Insert here
        //     // Maintain Export Certificate Status Change Record History
        //     ec.ExportCertificateStatusID = (short)status;
        //     ec.UpdatedOn = DateTime.Now;

        //     command.UnitOfWork.ExportCertificateRepository.Update(ec);
        // }

        // public static SDDetailedInformationResponseDTO getGDInformation(CommandRequest Command, SDDetailedInformationRequestDTO request, short agencyId, string StrategyName, string MethodID)
        // {
        //     var requestObj = new
        //     {
        //         sdid = request.SdId,
        //         agencyId = agencyId
        //     };

        //     var rabbitMQResponse = RabbitMqCallHelper<SDDetailedInformationResponseDTO>.SyncCall(requestObj, ServiceMethod.SD_GET_INFORMATION_BY_SDID, MessageQueues.SDRPCQueue);

        //     if (rabbitMQResponse != null)
        //     {
        //         Log.Information($"|{StrategyName}|{MethodID}| SD response: {rabbitMQResponse}");
        //         return rabbitMQResponse;
        //     }
        //     Log.Error($"|{StrategyName}|{MethodID}| SD response: null");
        //     return null;
        // }

        // public static long InsertReleaseOrderStatusChangeRecord(CommandRequest command, PSW.GMS.Data.Entities.ReleaseOrder releaseOrder, int newStatusID)
        // {
        //     // TODO: Implement Bulk Insert here
        //     // Maintain Export Certificate Status Change Record History
        //     ReleaseOrderStatusChangeRecord model = new ReleaseOrderStatusChangeRecord
        //     {
        //         ReleaseOrderID = releaseOrder.ID,
        //         CurrentStatusID = releaseOrder.ReleaseOrderStatusID,
        //         NewStatusID = (short)newStatusID,
        //         CreatedBy = 0,
        //         CreatedOn = DateTime.Now
        //     };

        //     return command.UnitOfWork.ReleaseOrderStatusChangeRecordRepository.AddAndReturnIdParam(model);
        // }

        // public static long InsertExportCertificateStatusChangeRecord(CommandRequest command, PSW.GMS.Data.Entities.ExportCertificate ec, int newStatusID)
        // {
        //     // TODO: Implement Bulk Insert here
        //     // Maintain Export Certificate Status Change Record History
        //     ExportCertificateStatusChangeRecord model = new ExportCertificateStatusChangeRecord
        //     {
        //         ExportCertificateID = ec.ID,
        //         CurrentStatusID = ec.ExportCertificateStatusID,
        //         NewStatusID = (short)newStatusID,
        //         CreatedBy = 0,
        //         CreatedOn = DateTime.Now
        //     };

        //     return command.UnitOfWork.ExportCertificateStatusChangeRecordRepository.AddAndReturnIdParam(model);
        // }

        // public static void UpdateReleaseOrderItemStatus(CommandRequest command, PSW.GMS.Data.Entities.ReleaseOrderItem releaseOrderItem, int status)
        // {
        //     // Update ReleaseOrderItem Status
        //     releaseOrderItem.ReleaseOrderItemStatusID = (short)status;
        //     releaseOrderItem.UpdatedOn = DateTime.Now;
        // }

        // public static void UpdateExportCertificateItemStatus(CommandRequest command, PSW.GMS.Data.Entities.ExportCertificateItem ecItem, int status)
        // {
        //     ecItem.ExportCertificateID = (short)status;
        //     ecItem.UpdatedOn = DateTime.Now;
        // }

        // public static long InsertReleaseOrderItemStatusChangeRecord(CommandRequest command, PSW.GMS.Data.Entities.ReleaseOrder releaseOrder, PSW.GMS.Data.Entities.ReleaseOrderItem releaseOrderItem, int newStatusID, int userRoleId, string comments)
        // {
        //     ReleaseOrderItemStatusChangeRecord itemModel = new ReleaseOrderItemStatusChangeRecord();

        //     itemModel.ReleaseOrderID = releaseOrder.ID;
        //     itemModel.ReleaseOrderItemID = releaseOrderItem.ID;
        //     itemModel.CurrentStatusID = (short)releaseOrderItem.ReleaseOrderItemStatusID;
        //     itemModel.NewStatusID = (short)newStatusID;
        //     itemModel.CreatedBy = userRoleId;
        //     itemModel.CreatedOn = DateTime.Now;
        //     itemModel.Comments = comments;
        //     return command.UnitOfWork.ReleaseOrderItemStatusChangeRecordRepository.Add(itemModel);
        // }

    }
}