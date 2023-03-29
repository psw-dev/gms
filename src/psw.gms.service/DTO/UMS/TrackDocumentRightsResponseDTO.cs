using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class TrackDocumentRightsResponseDTO
    {

        [JsonPropertyName("isPermitted")]
        public bool IsPermitted { get; set; }

        [JsonPropertyName("officerName")]
        public string OfficerName { get; set; }

        [JsonPropertyName("officerUserName")]
        public string OfficerUserName { get; set; }

        [JsonPropertyName("officerRole")]
        public string OfficerRole { get; set; }

        [JsonPropertyName("documentID")]
        public long DocumentID { get; set; }

    }
}