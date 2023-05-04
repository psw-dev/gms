using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetGuaranteeHistoryResponseDTO : GetGuaranteeHistoryDTO
    {
        [JsonPropertyName("iD")]
        public long ID { get; set; }

        [JsonPropertyName("attachedToDocumentID")]
        public long AttachedToDocumentID { get; set; }

        [JsonPropertyName("attachedToDocumentNumber")]
        public string AttachedToDocumentNumber { get; set; }

        [JsonPropertyName("attachedToDocumentTypeCode")]
        public string AttachedToDocumentTypeCode { get; set; }

        [JsonPropertyName("consumedAmount")]
        public double? ConsumedAmount { get; set; }

        [JsonPropertyName("guaranteeTransactionStatusID")]
        public int GuaranteeTransactionStatusID { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("rejectedOn")]
        public DateTime? RejectedOn { get; set; }
    }
}