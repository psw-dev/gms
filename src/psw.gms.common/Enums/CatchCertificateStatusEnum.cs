using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum CatchCertificateStatusEnum
    {
        [Description("Approved")]
        APPROVED = 1,

        [Description("Cancelled")]
        CANCELLED = 2,

        [Description("Payment Received")]
        PAYMENT_RECEIVED = 3,
        [Description("Assigned To Officer")]
        ASSIGNED_TO_OFFICER = 4,

        [Description("Submitted")]
        SUBMITTED = 5,

        [Description("Payment Awaited")]
        PAYMENT_AWAITED = 6


    }


}