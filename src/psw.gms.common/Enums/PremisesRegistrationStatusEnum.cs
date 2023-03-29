using System.ComponentModel;
namespace PSW.GMS.Common.Enums
{
    public enum PremisesRegistrationStatusEnum
    {
        [Description("Saved")]
        SAVED = 1,

        [Description("Submitted")]
        SUBMITTED = 2,

        [Description("Payment Received")]
        PAYMENT_RECEIVED = 3,

        [Description("Cancelled")]
        CANCELLED = 4,

        [Description("Documents Called")]
        DOCUMENTS_CALLED = 5,

        [Description("Documents Submitted")]
        DOCUMENTS_SUBMITTED = 6,

        [Description("Registered")]
        REGISTERED = 7,

        [Description("Rejected")]
        REJECTED = 8,

        [Description("Assigned To Officer")]
        ASSIGNED_TO_OFFICER = 9,

        [Description("Call Document Request Cancelled")]
        CALL_DOCUMENT_REQUEST_CANCELLED = 10,

        [Description("Call Document Request Reverted")]
        CALL_DOCUMENT_REQUEST_REVERTED = 11,

        [Description("Expired")]
        EXPIRED = 13,

        [Description("Payment Awaited")]
        PAYMENT_AWAITED = 15,

        [Description("Draft")]
        DRAFT = 18,

        [Description("Suspended")]
        SUSPENDED = 19
    }
}