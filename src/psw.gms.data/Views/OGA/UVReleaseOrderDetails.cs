/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Objects.Views
{
    public class UVReleaseOrderDetails : Entity
    {
        #region Properties


        public long ReleaseOrderId { get; set; }
        public string SDNumber { get; set; }
        public string TraderName { get; set; }
        public string AgentName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Age { get; set; }
        public long ID { get; set; }
        public short AgencyID { get; set; }
        public string RequestDocumentTypeCode { get; set; }
        public string RequestDocumentNumber { get; set; }
        public string IntrmDocumentTypeCode { get; set; }
        public string IntrmDocumentNumber { get; set; }
        public DateTime? IntrmROIssueDate { get; set; }
        public DateTime? IntrmROEffectiveDate { get; set; }
        public DateTime? IntrmROExpiryDate { get; set; }
        public DateTime? IntrmROCancellationDate { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public int ConsigneeSubscriptionID { get; set; }
        public int? AgentSubscriptionID { get; set; }
        public string ConsigneeName { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddressFull { get; set; }
        public string ApplNumStreetPOBox { get; set; }
        public string ApplCountryCode { get; set; }
        public string ApplCountrySubEntityCode { get; set; }
        public int? ApplCityID { get; set; }
        public string ApplPostalCode { get; set; }
        public string NTN { get; set; }
        public long SDID { get; set; }
        public string SDDocumentNumber { get; set; }
        public int? IRMSChannelID { get; set; }
        public long? BillID { get; set; }
        public decimal? BillAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? ClosedOn { get; set; }
        public short TotalItemsCount { get; set; }
        public short ApprovedItemsCount { get; set; }
        public short RejectedItemsCount { get; set; }
        public short PendingItemsCount { get; set; }
        public string Comments { get; set; }
        public int ReleaseOrderStatusID { get; set; }
        public System.Byte[] LastChange { get; set; }

        #endregion
    }
}