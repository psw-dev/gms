
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
using System.Linq;
using System.Collections.Generic;

namespace PSW.GMS.Service.Helpers
{
    public static class UMSHelper
    {
        /// <summary>
        /// GetUserInformation
        /// </summary>
        /// <param name="cmd">CommandRequest cmd</param>
        /// <param name="userRoleId">int? userRoleId</param>
        /// <returns>UserInformationResponseDTO</returns>
        public static UserInformationResponseDTO GetUserInformation(CommandRequest cmd, int? userRoleId)
        {
            var request = new UserInformationRequestDTO
            {
                UserRoleID = userRoleId
            };

            var rabbitMQResponse = RabbitMqCallHelper<UserInformationResponseDTO>.SyncCall(request, ServiceMethod.UMS_GET_DOCUMENT_ASSIGNEE, MessageQueues.UMSRPCQueue);

            if (rabbitMQResponse != null)
            {
                return rabbitMQResponse;
            }

            return null;
        }

        /// <summary>
        /// GetDocumentAssigneeInfo
        /// </summary>
        /// <param name="cmd">CommandRequest cmd</param>
        /// <param name="documents">List<DocumentRightsRequest> documents</param>
        /// <param name="documentClassificationCode">string documentClassificationCode</param>
        /// <param name="isActivityLog">bool isActivityLog = false</param>
        /// <returns>List<DocumentAssigneeInfoResponseDTO></returns>
        public static List<DocumentAssigneeInfoResponseDTO> GetDocumentAssigneeInfo(CommandRequest cmd, List<DocumentRightsRequest> documents, string documentClassificationCode, bool isActivityLog = false)
        {
            var request = new DocumentAssigneeInfoRequestDTO()
            {
                IsActivityLog = isActivityLog,
                AspNetUserId = cmd.AspNetUserId,
                DocumentClassificationCode = documentClassificationCode,
                DocumentAssigneeList = new List<DocumentAssignee>()

            };

            foreach (var document in documents)
            {

                request.DocumentAssigneeList.Add(new DocumentAssignee()
                {
                    UserRoleID = document.OfficerRoleID,
                    AgencyID = document.AgencyID,
                    DocumentTypeCode = document.DocumentTypeCode,
                    DocumentID = document.DocumentID,
                    IsLoggedEntry = document.IsLoggedEntry
                });
            }

            var rabbitMQResponse = RabbitMqCallHelper<List<DocumentAssigneeInfoResponseDTO>>.SyncCall(request, ServiceMethod.UMS_GET_DOCUMENT_ASSIGNEE_INFORMATION, MessageQueues.UMSRPCQueue);

            if (rabbitMQResponse != null)
            {
                return rabbitMQResponse;
            }

            return null;
        }

        public static string GetCurrentAssigneeName(long documentId, string documentTypeCode, List<Byte> listStatuses, List<string> listRoleCodes)
        {
            try
            {
                var assignedUserInformationRequest = new AssignedUserInformationRequestDTO
                {
                    DocumentId = documentId,
                    DocumentTypeCode = documentTypeCode,
                    ListDocumentAssignmentStatusID = listStatuses,
                    ListRoleCode = listRoleCodes
                };

                var assignedUserInformationResponse = RabbitMqCallHelper<AssignedUserInformationResponseDTO>.SyncCall(assignedUserInformationRequest, ServiceMethod.UMS_GET_ASSIGNED_USER_INFORMATION, MessageQueues.UMSRPCQueue);

                return assignedUserInformationResponse?.PersonName ?? "N/A";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TraderBasicInformationResponseDTO GetTraderBasicInformation(string roleCode, IEnumerable<System.Security.Claims.Claim> userClaims)
        {
            try
            {
                var usernameClaim = userClaims.Where(x => x.Type == "username").ToList().ElementAt(0);

                var traderBasicInformationRequest = new TraderBasicInformationRequestDTO
                {
                    RoleCode = roleCode,
                    UserName = usernameClaim.Value
                };

                var traderBasicInformationResponse = RabbitMqCallHelper<TraderBasicInformationResponseDTO>.SyncCall(traderBasicInformationRequest, ServiceMethod.AUTH_GET_TRADER_BASIC_INFORMATION, MessageQueues.AUTHRPCQueue);

                return traderBasicInformationResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}