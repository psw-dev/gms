using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class AssignedUserInformationRequestDTO
    {
        [JsonPropertyName("documentId")]
        public long DocumentId { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("listDocumentAssignmentStatusId")]
        public List<byte> ListDocumentAssignmentStatusID { get; set; }

        [JsonPropertyName("listRoleCode")]
        public List<string> ListRoleCode { get; set; }
    }
}