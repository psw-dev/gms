using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetAllAllowedOperationAgainstDocumentResponseDTO
    {

        [JsonPropertyName("agencyID")]
        public int agencyID { get; set; }
        [JsonPropertyName("documentClassificationCode")]
        public string documentClassificationCode { get; set; }

        [JsonPropertyName("certificateDocumentTypeCode")]
        public string documentTypeCode { get; set; }

        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("tradeType")]
        public int tradeType { get; set; }
    }
}