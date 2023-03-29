using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class TraderBasicInformationRequestDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}