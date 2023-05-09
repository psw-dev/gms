using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UpdateGuaranteeTransactionDTO
    {
        [JsonPropertyName("guaranteeID")]
        public long GuaranteeID { get; set; }

        [JsonPropertyName("attachedToDocumentID")]
        public long AttachedToDocumentID { get; set; }

        [JsonPropertyName("attachedToDocumentNumber")]
        public string AttachedToDocumentNumber { get; set; }

        [JsonPropertyName("attachedToDocumentTypeCode")]
        public string AttachedToDocumentTypeCode { get; set; }

        [JsonPropertyName("consumedAmount")]
        public decimal? ConsumedAmount { get; set; }

        [JsonPropertyName("guaranteeTransactionStatusID")]
        public int GuaranteeTransactionStatusID { get; set; }
    }
}