using PSW.GMS.Service.Helpers;
using PSW.LogDB;
using PSW.LogDB.Data.Entities;
using PSW.GMS.Service.Command;
using System;

namespace PSW.GMS.Service.Helpers
{
    public class ActivityLogHelper
    {
        public static void Write(int userRoleId, int aspNetUserId, int activityId, string addionalInfoJson, string description, string documentTypeCode, long documentId, string requestDocumentNumber, long? sdid, bool isAgeComputable = true, short srcModuleId = 2)
        {
            try
            {
                DocumentActivityLog activityLog = new DocumentActivityLog();

                activityLog.UserRoleID = userRoleId;
                activityLog.AspnetUserID = aspNetUserId;
                activityLog.ActivityID = activityId;
                activityLog.AdditionalInfoJson = addionalInfoJson;
                activityLog.ActivityDescription = description;
                activityLog.DocumentTypeCode = documentTypeCode;
                activityLog.DocumentID = documentId;
                activityLog.DocumentNumber = requestDocumentNumber;
                activityLog.SDID = sdid ?? 0;
                activityLog.IsAgeComputable = isAgeComputable;
                activityLog.SrcModuleID = srcModuleId;
                activityLog.CreatedDt = DateTime.Now;
                activityLog.ActivityOn = DateTime.Now;

                ActivityLogger.AddLog(activityLog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}