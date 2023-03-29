using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class DeleteAttachmentRequestDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("ownerDocumentTypeCode")]
        public string OwnerDocumentTypeCode { get; set; }

        [JsonPropertyName("ownerDocumentID")]
        public long OwnerDocumentID { get; set; }

        [JsonPropertyName("agencyId")]
        public long AgencyId { get; set; }

        [JsonPropertyName("identification")]
        public string Identification { get; set; }
    }
}
