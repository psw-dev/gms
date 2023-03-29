using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class DocumentAssigneeInfoRequestDTO
    {
        [JsonPropertyName("isActivityLog")]
        public bool IsActivityLog { get; set; }

        [JsonPropertyName("aspNetUserId")]
        public int AspNetUserId { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("documentAssigneeList")]
        public List<DocumentAssignee> DocumentAssigneeList { get; set; }
    }
    public class DocumentAssignee
    {

        [JsonPropertyName("userRoleID")]
        public int UserRoleID { get; set; }

        [JsonPropertyName("agencyID")]
        public short AgencyID { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("documentID")]
        public long DocumentID { get; set; }

        [JsonPropertyName("isLoggedEntry")]
        public bool IsLoggedEntry { get; set; }
    }
}