using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveGuaranteeDocumentResponseDTO : SaveGuaranteeDocumentDTO
    {
        [JsonPropertyName("iD")]
        public long ID { get; set; }

        [JsonPropertyName("issueDate")]
        public DateTime IssueDate { get; set; }

        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("guaranteeStatusID")]
        public int GuaranteeStatusID { get; set; }

        [JsonPropertyName("balanceAmount")]
        public double BalanceAmount { get; set; }
    }
}