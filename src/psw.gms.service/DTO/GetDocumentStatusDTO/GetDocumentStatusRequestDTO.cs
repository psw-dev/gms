using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetDocumentStatusRequestDTO
    {
        [JsonPropertyName("documentID")]
        public int DocumentID { get; set; }

        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }


    }
}
