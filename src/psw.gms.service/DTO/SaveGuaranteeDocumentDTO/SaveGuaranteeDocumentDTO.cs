using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveGuaranteeDocumentDTO
    {
        [JsonPropertyName("guaranteeTypeID")]
        public int GuaranteeTypeID { get; set; }

        [JsonPropertyName("traderNTN")]
        public string TraderNTN { get; set; }

        [JsonPropertyName("agentNTN")]
        public string AgentNTN { get; set; }

        [JsonPropertyName("guaranteeNumber")]
        public string GuaranteeNumber { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("bankCode")]
        public string BankCode { get; set; }
    }
}