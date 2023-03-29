using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UploadNationalRegisterRequestDTO
    {

        [JsonPropertyName("filepath")]
        public string FilePath { get; set; }

        [JsonPropertyName("fileId")]
        public long FileID { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("requestDocumentTypeCode")]
        public string RequestDocumentTypeCode { get; set; }

        [JsonPropertyName("agencyId")]
        public int AgencyID { get; set; }

        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }
    }
}
