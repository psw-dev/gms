using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UploadProgressRequestDTO
    {
        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("requestDocumentTypeCode")]
        public string RequestDocumentTypeCode { get; set; }

    }
}
