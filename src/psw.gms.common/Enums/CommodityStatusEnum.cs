using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum CommodityHDRStatusEnum
    {
        SAVED = 1,

        [Description("Submitted")]
        SUBMITTED = 2,
        PAYMENT_RECEIVED = 3,
        CANCELLED = 4,
        DOCUMENTS_CALLED = 5,
        DOCUMENTS_SUBMITTED = 6,

        [Description("Approved")]
        APPROVED = 7,

        [Description("Rejected")]
        REJECTED = 8,
        ASSIGNED_TO_OFFICER = 9,
        CALL_DOCUMENT_REQUEST_CANCELLED = 10,
        CALL_DOCUMENT_REQUEST_REVERTED = 11,
        COMPLETED = 12,
        EXPIRED = 13
    }

    public enum CommodityStatusEnum
    {
        PENDING = 4,
        // CALL_DOCUMENT = 2,
        [Description("Approved")]
        APPROVED = 1,

        [Description("Rejected")]
        REJECTED = 3,
        INACTIVE = 5,
        ACTIVE = 6
    }
}