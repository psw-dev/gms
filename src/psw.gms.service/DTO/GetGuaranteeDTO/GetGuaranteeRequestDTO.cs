using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetGuaranteeRequestDTO : GetGuaranteeDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("agentParentCollectorateCode")]
        public string AgentParentCollectorateCode { get; set; }
    }
}