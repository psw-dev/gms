using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetTraderInformationRequestDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("initDocumentId")]
        public long InitDocumentID { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("isIndependent")]
        public bool IsIndependent { get; set; }

        [JsonPropertyName("rights")]
        public string Rights { get; set; }

    }

}
