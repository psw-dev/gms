namespace PSW.GMS.Common.Enums
{
    public enum SeedEnlistmentStatusEnum
    {
        SAVED = 1,
        SUBMITTED = 2,
        PAYMENT_RECEIVED = 3,
        CANCELLED = 4,
        DOCUMENTS_CALLED = 5,
        DOCUMENTS_SUBMITTED = 6,
        APPROVED = 7,
        REJECTED = 8,
        ASSIGNED_TO_OFFICER = 9,
        CALL_DOCUMENT_REQUEST_CANCELLED = 10,
        CALL_DOCUMENT_REQUEST_REVERTED = 11,
        COMPLETED = 12,
        EXPIRED = 13
    }

    public enum SeedEnlistmentCommodityStatusEnum
    {
        PENDING = 4,
        // CALL_DOCUMENT = 2,
        APPROVED = 1,
        REJECTED = 3,
        INACTIVE = 5,
        ACTIVE = 6
    }
}