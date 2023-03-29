using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class TrackDocumentResponseDTO
    {
        [JsonPropertyName("sd")]
        public string SD { get; set; }

        [JsonPropertyName("gd")]
        public string GD { get; set; }

        [JsonPropertyName("gdStatus")]
        public string GDStatus { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("trackedDocuments")]
        public List<TrackedDocument> TrackedDocuments { get; set; }
    }

    public class TrackedDocument
    {
        [JsonPropertyName("requestDocumentNumber")]
        public string RequestDocumentNumber { get; set; }

        [JsonPropertyName("agencyName")]
        public string AgencyName { get; set; }

        [JsonPropertyName("agencySiteName")]
        public string AgencySiteName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // [JsonPropertyName("userName")]
        // public string UserName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("currentDocumentStatus")]
        public string CurrentDocumentStatus { get; set; }
    }
}
