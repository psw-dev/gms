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

        [JsonPropertyName("traderRoleID")]
        public int TraderRoleID { get; set; }

        [JsonPropertyName("traderSubscriptionID")]
        public int TraderSubscriptionID { get; set; }

        [JsonPropertyName("agentSubscriptionID")]
        public int AgentSubscriptionID { get; set; }

        [JsonPropertyName("agentNTN")]
        public string AgentNTN { get; set; }

        [JsonPropertyName("agentRoleID")]
        public int AgentRoleID { get; set; }

        [JsonPropertyName("agentParentCollectorateCode")]
        public string AgentParentCollectorateCode { get; set; }

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
    }
}