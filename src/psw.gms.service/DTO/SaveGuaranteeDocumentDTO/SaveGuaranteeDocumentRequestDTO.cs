using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveGuaranteeDocumentRequestDTO : SaveGuaranteeDocumentDTO
    {
        public DateTime issueDate;
        public DateTime expiryDate;

        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("traderRoleID")]
        public int TraderRoleID { get; set; }

        [JsonPropertyName("traderSubscriptionID")]
        public int TraderSubscriptionID { get; set; }

        [JsonPropertyName("agentParentCollectorateCode")]
        public string AgentParentCollectorateCode { get; set; }

        [JsonPropertyName("issueDate")]
        public DateTime IssueDate { get => issueDate.ToLocalTime(); set => issueDate = value; }

        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get => expiryDate.ToLocalTime(); set => expiryDate = value; }
    }
}