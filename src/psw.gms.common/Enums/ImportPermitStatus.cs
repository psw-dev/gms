using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum ImportPermitStatus
    {
        [Description("Saved")]
        SAVED = 1,

        [Description("Submitted")]
        SUBMITTED = 2,

        [Description("Payment Received")]
        PAYMENT_RECEIVED = 3,

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

        [Description("Channel Assigned")]
        CHANNEL_ASSIGNED = 14,

        [Description("Assigned To Officer")]
        ASSIGNED_TO_OFFICER = 15,

    }

    public enum ImportPermitAmendmentStatus
    {
        SUBMITTED = 1,
        PAYMENT_RECEIVED = 2,
        OFFICER_QUEUE = 3,
        APPROVAL_FOR_CALL_DOCUMENT = 4,
        DOCUMENTS_CALLED = 5,
        DOCUMENTS_SUBMITTED = 6,
        REFERRED = 7,
        AMENDMENT_APPROVED = 8,
        AMENDMENT_REJECTED = 9,
        CALL_DOCUMENT_REJECTED = 10,
        CALL_DOCUMENT_REQUEST_REVERTED = 11,
        CALL_DOCUMENT_REQUEST_CANCELLED = 12,
        ASSIGNED_TO_OFFICER = 13,

    }
}