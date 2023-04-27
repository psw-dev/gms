using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveGuaranteeDocumentResponseDTO : SaveGuaranteeDocumentDTO
    {
        [JsonPropertyName("iD")]
        public long ID { get; set; }

        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("guaranteeStatusID")]
        public int GuaranteeStatusID { get; set; }
    }
}