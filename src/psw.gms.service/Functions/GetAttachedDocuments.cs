using System;
using System.Collections.Generic;
using System.Linq;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
// using CallDocumentStatus = PSW.GMS.Common.Constants.CallDocumentStatus;

namespace PSW.GMS.Service.Functions
{
    public static class GetAttachedDocuments
    {
        // public static List<PSW.GMS.Service.DTO.DocumentAttachment> GetAttachedDocumentsById(CommandRequest command, long documentId, string documentTypeCode, string documentClassificationCode)
        // {


        //     List<DocumentAttachment> attachments = new List<DocumentAttachment>();


        //     var attachmentList =
        //         command.UnitOfWork.CallDocumentAttachmentRepository.GetAllAttachedDocumentsById(Convert.ToInt64(documentId), documentTypeCode, documentClassificationCode);


        //     foreach (var attachment in attachmentList)
        //     {
        //         DocumentAttachment docAttachment = new DocumentAttachment();
        //         docAttachment.FileNestFileIds = command.CryptoAlgorithm.Encrypt(attachment.FileNestFileId.ToString());
        //         docAttachment.FileNestFileId = attachment.FileNestFileId;
        //         docAttachment.DocumentName = attachment.DocumentName;
        //         docAttachment.DocTypeName = attachment.DocumentName;
        //         docAttachment.DocTypeCode = attachment.DocTypeCode;

        //         attachments.Add(docAttachment);
        //     }


        //     return attachments;
        // }
    }
}