using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class AssignedUserInformationResponseDTO
    {
        [JsonPropertyName("documentId")]
        public long DocumentId { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("userRoleID")]
        public long UserRoleID { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("personName")]
        public string PersonName { get; set; }
    }
}