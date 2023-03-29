
using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum PremisesRegistrationAmendmentStatusEnum
    {
        SAVED = 1,
        SUBMITTED = 2,
        PAYMENT_RECEIVED = 3,
        CANCELLED = 4,
        DOCUMENTS_CALLED = 5,
        DOCUMENTS_SUBMITTED = 6,
        REGISTERED = 7,
        REJECTED = 8,
        ASSIGNED_TO_OFFICER = 9,
        CALL_DOCUMENT_REQUEST_CANCELLED = 10,
        CALL_DOCUMENT_REQUEST_REVERTED = 11,
        EXPIRED = 13,
        APPROVED = 14,
        PARTIAL_APPROVED = 15,
        PENDING = 16,
        [Description("Waiting for Payment")]
        PAYMENT_AWAITED = 17
    }
}