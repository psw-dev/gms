using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class SaveAttachmentRequestDTO
    {
        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

        [JsonPropertyName("ownerDocumentTypeCode")]
        public string OwnerDocumentTypeCode { get; set; }

        [JsonPropertyName("ownerDocumentID")]
        public long OwnerDocumentID { get; set; }

        [JsonPropertyName("attachments")]
        public List<SaveAttachmentDTO> Attachments { get; set; }
    }

    public class SaveAttachmentDTO
    {
        [JsonPropertyName("ownerDocumentTypeCode")]
        public string OwnerDocumentTypeCode { get; set; }

        [JsonPropertyName("ownerDocumentID")]
        public long OwnerDocumentID { get; set; }

        [JsonPropertyName("attachedObjectFormatID")]
        public short AttachedObjectFormatID { get; set; }

        [JsonPropertyName("attachedDocumentTypeCode")]
        public string AttachedDocumentTypeCode { get; set; }

        [JsonPropertyName("attachedDocumentID")]
        public long AttachedDocumentID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("attachmentID")]
        public long AttachmentID { get; set; }
    }
}
