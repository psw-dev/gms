using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveGuaranteeDocumentRequestDTO : SaveGuaranteeDocumentDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }
    }
}