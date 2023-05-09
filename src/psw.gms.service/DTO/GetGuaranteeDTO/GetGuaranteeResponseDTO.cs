using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetGuaranteeResponseDTO : GetGuaranteeDTO
    {
        [JsonPropertyName("guaranteeTypeID")]
        public int GuaranteeTypeID { get; set; }

        [JsonPropertyName("guaranteeNumber")]
        public string GuaranteeNumber { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("issueDate")]
        public DateTime IssueDate { get; set; }

        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonPropertyName("bankCode")]
        public string BankCode { get; set; }

        [JsonPropertyName("balanceAmount")]
        public double BalanceAmount { get; set; }

        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("guaranteeStatusID")]
        public int GuaranteeStatusID { get; set; }
    }
}