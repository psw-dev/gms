using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class TrackDocumentRightsRequestDTO
    {
        [JsonPropertyName("aspNetUserId")]
        public int AspNetUserId { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("trackDocumentRight")]
        public List<TrackDocumentRight> TrackDocumentRights { get; set; }
    }
    public class TrackDocumentRight
    {

        [JsonPropertyName("userRoleID")]
        public int UserRoleID { get; set; }

        [JsonPropertyName("agencyID")]
        public short AgencyID { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("documentID")]
        public long DocumentID { get; set; }
    }
}