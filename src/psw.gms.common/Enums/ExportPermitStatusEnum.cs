using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum ExportPermitStatusEnum
    {
        [Description("Saved")]
        SAVED = 1,

        [Description("Submitted")]
        SUBMITTED = 2,


        [Description("Cancelled")]
        CANCELLED = 4,

        [Description("Approval For Call Document")]
        APPROVAL_FOR_CALL_DOCUMENT = 5,

        [Description("Documents Called")]
        DOCUMENTS_CALLED = 6,

        [Description("Documents Submitted")]
        DOCUMENTS_SUBMITTED = 7,

        [Description("Referred")]
        REFERRED = 8,

        [Description("Approved")]
        APPROVED = 9,

        [Description("Rejected")]
        REJECTED = 10,

        [Description("Call Document Rejected")]
        CALL_DOCUMENT_REJECTED = 11,

        [Description("Call Document Request Reverted")]
        CALL_DOCUMENT_REQUEST_REVERTED = 12,

        [Description("Call Document Request Cancelled")]
        CALL_DOCUMENT_REQUEST_CANCELLED = 13,

        [Description("Assigned To Officer")]
        ASSIGNED_TO_OFFICER = 15,



    }


}