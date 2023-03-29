using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum ReleaseOrderStatus
    {
        [Description("Submitted")]
        SUBMITTED = 1,

        [Description("Assigned To Officer")]
        ASSIGNED_TO_OFFICER = 2,

        [Description("Approved")]
        APPROVED = 3,

        [Description("Rejected")]
        REJECTED = 4,

        [Description("Approval For Call Document")]
        APPROVAL_FOR_CALL_DOCUMENT = 5,

        [Description("Documents Called")]
        DOCUMENTS_CALLED = 6,

        [Description("Approval For Call Labs")]
        APPROVAL_FOR_CALL_LABS = 7,

        [Description("Labs Called")]
        LABS_CALLED = 8,

        [Description("Call Document Request Reverted")]
        CALL_DOCUMENT_REQUEST_REVERTED = 9,

        [Description("Approval For Physical Inspection")]
        APPROVAL_FOR_PHYSICAL_INSPECTION = 10,

        [Description("Examination In Progress")]
        EXAMINATION_IN_PROGRESS = 11,

        [Description("Documents Submitted")]
        DOCUMENTS_SUBMITTED = 12,

        [Description("Lab Report Submitted")]
        LAB_REPORT_SUBMITTED = 13,

        [Description("Call Document Request Cancelled")]
        CALL_DOCUMENT_REQUEST_CANCELLED = 14,

        [Description("Inspection Documents Submitted")]
        INSPECTION_DOCUMENTS_SUBMITTED = 15,

        [Description("Call Documents Request Rejected")]
        CALL_DOCUMENT_REQUEST_REJECTED = 16,

        [Description("Physical Inspection Rejected")]
        PHYSICAL_INSPECTION_REJECTED = 17,

        [Description("Lab Request Rejected")]
        LAB_REQUEST_REJECTED = 18,

        [Description("Approval For Call Document Requested By IO")]
        APPROVAL_FOR_CALL_DOCUMENT_REQUESTED_BY_IO = 19,

        [Description("Documents Called Requested By IO")]
        DOCUMENTS_CALLED_REQUESTED_BY_IO = 20,

        [Description("Call Document Request Rejected Requested By IO")]
        CALL_DOCUMENT_REQUEST_REJECTED_REQUESTED_BY_IO = 21,

        [Description("Documents Submitted Requested By IO")]
        DOCUMENTS_SUBMITTED_REQUESTED_BY_IO = 22,

        [Description("Partial Approved")]
        PARTIAL_APPROVED = 23,

        [Description("Call Document Request Cancelled Requested By IO")]
        CALL_DOCUMENT_REQUEST_CANCELLED_REQUESTED_BY_IO = 24,

        [Description("Fumigation Requested")]
        FUMIGATION_REQUESTED = 25,

        [Description("Fumigation Request Submitted")]
        FUMIGATION_REPORT_SUBMITTED = 26,

        [Description("Channel Assigned")]
        CHANNEL_ASSIGNED = 27,

        [Description("Payment Awaited")]
        PAYMENT_AWAITED = 28,

        [Description("Payment Received")]
        PAYMENT_RECEIVED = 29,

        [Description("Waiting For Grounding")]
        WAITING_FOR_GROUNDING = 30,

        [Description("Physical Inspection Request Approved")]
        PHYSICAL_INSPECTION_REQUEST_APPROVED = 31,

        [Description("Temporary Release Certificate")]
        TEMPORARY_RELEASE_CERTIFICATE = 32,

        [Description("Non Conformity Release Certificate")]
        NON_COMFORMATOY_RELEASE_CERTIFICATE = 33,

        [Description("Waiting For Approval")]
        WAITING_FOR_APPROVAL = 34,

        [Description("Submitted Called Documents Sent To Agency")]
        SUBMITTED_CALLED_DOCUMENTS_SENT_TO_AGENCY = 35,

        [Description("Lab Payment Awaited")]
        LAB_PAYMENT_AWAITED = 36,

        [Description("Lab Payment Received")]
        LAB_PAYMENT_RECEIVED = 37,

        [Description("Cancelled")]
        CANCELLED = 38,

        [Description("Review Submitted")]
        REVIEW_SUBMITTED = 39
    }

    public enum ReleaseOrderItemStatus
    {
        PENDING = 1,
        CALL_DOCUMENT = 2,
        CALL_INSPECTION = 3,
        APPROVED = 4,
        REJECTED = 5,
    }

    public enum ReleaseCertificateTypeCode
    {
        TRC = 1,
        RC = 2,
        CAR = 3,
        NCAR = 4
    }

}