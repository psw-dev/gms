using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UpdateGuaranteeTransactionRequestDTO : UpdateGuaranteeTransactionDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("traderNTN")]
        public string TraderNTN { get; set; }

        [JsonPropertyName("agentNTN")]
        public string AgentNTN { get; set; }

        [JsonPropertyName("agentParentCollectorateCode")]
        public string AgentParentCollectorateCode { get; set; }
    }
}