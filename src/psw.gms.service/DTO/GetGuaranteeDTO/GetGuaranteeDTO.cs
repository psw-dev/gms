using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetGuaranteeDTO
    {
        [JsonPropertyName("iD")]
        public long ID { get; set; }

        [JsonPropertyName("traderNTN")]
        public string TraderNTN { get; set; }

        [JsonPropertyName("agentNTN")]
        public string AgentNTN { get; set; }
    }
}