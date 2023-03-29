using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum ExportCertificateStatus
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

        [Description("Approval For Physical Inspection Request")]
        APPROVAL_FOR_PHYSICAL_INSPECTION_REQUEST = 9,

        [Description("Examination In Progress")]
        EXAMINATION_IN_PROGRESS = 10,

        [Description("Documents Submitted")]
        DOCUMENTS_SUBMITTED = 11,

        [Description("Lab Report Submitted")]
        LAB_REPORT_SUBMITTED = 12,

        [Description("Inspection Documents Submitted")]
        INSPECTION_DOCUMENTS_SUBMITTED = 13,

        [Description("Call Document Request Rejected")]
        CALL_DOCUMENT_REQUEST_REJECTED = 14,

        [Description("Physical Inspection Request Rejected")]
        PHYSICAL_INSPECTION_REQUEST_REJECTED = 15,

        [Description("Lab Request Rejected")]
        LAB_REQUEST_REJECTED = 16,

        [Description("Call Document Request Reverted")]
        CALL_DOCUMENT_REQUEST_REVERTED = 17,

        [Description("Call Document Request Cancelled")]
        CALL_DOCUMENT_REQUEST_CANCELLED = 18,

        [Description("Approval For Call Document Requested By IO")]
        APPROVAL_FOR_CALL_DOCUMENT_REQUESTED_BY_IO = 19,

        [Description("Documents Called Requested By IO")]
        DOCUMENTS_CALLED_REQUESTED_BY_IO = 20,

        [Description("Call Document Request Rejected Requested By IO")]
        CALL_DOCUMENT_REQUEST_REJECTED_REQUESTED_BY_IO = 21,

        [Description("Documents Submitted Requested By IO")]
        DOCUMENTS_SUBMITTED_REQUESTED_BY_IO = 22,

        [Description("Call Document Request Cancelled Requested By Io")]
        CALL_DOCUMENT_REQUEST_CANCELLED_REQUESTED_BY_IO = 23,

        [Description("Fumigation Requested")]
        FUMIGATION_REQUESTED = 24,

        [Description("Fumigation Report Submitted")]
        FUMIGATION_REPORT_SUBMITTED = 25,

        [Description("Channel Assigned")]
        CHANNEL_ASSIGNED = 26,

        [Description("Payment Awaited")]
        PAYMENT_AWAITED = 27,

        [Description("Payment Received")]
        PAYMENT_RECEIVED = 28,

        [Description("Partial Approved")]
        PARTIAL_APPROVED = 29,

        [Description("Waiting For Grounding")]
        WAITING_FOR_GROUNDING = 30,

        [Description("Physical Inspection Request Approved")]
        PHYSICAL_INSPECTION_REQUEST_APPROVED = 31,

        [Description("Cancelled")]
        CANCELLED = 32,
        /*
        the status AMENDMENT_REQUESTED is only created to be used to notify the Trader/Custom Agent 
        that the amendment has been requested. 
        It will not be use to change the Export Certificate Stauts.
        */
        [Description("Amendment Requested")]
        AMENDMENT_REQUESTED = 33,

        [Description("Transferred")]
        TRANSFERRED = 34,

        [Description("ReviewSubmitted")]
        REVIEW_SUBMITTED = 35
    }

    public enum ExportCertificateItemStatus
    {
        PENDING = 1,
        CALL_DOCUMENT = 2,
        CALL_INSPECTION = 3,
        APPROVED = 4,
        REJECTED = 5,
    }
}