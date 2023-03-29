using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class TrackDocumentRequestDTO
    {
        [JsonPropertyName("requestDocumentNumber")]
        public string RequestDocumentNumber { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }
    }
    public class TrackDocumentRequest
    {
        public long ID { get; set; }
        public string RequestDocumentNumber { get; set; }
        public string DocumentClassificationCode { get; set; }
        public short AgencyID { get; set; }
        public int UserRoleID { get; set; }
        public int AgencySiteID { get; set; }
        public short StatusID { get; set; }
        public bool IsActivityLog { get; set; } = false;
    }
    public class DocumentRightsRequest
    {
        public long DocumentID { get; set; }
        public int OfficerRoleID { get; set; }
        public short AgencyID { get; set; }
        public string DocumentTypeCode { get; set; }
        public bool IsLoggedEntry { get; set; }
    }
}