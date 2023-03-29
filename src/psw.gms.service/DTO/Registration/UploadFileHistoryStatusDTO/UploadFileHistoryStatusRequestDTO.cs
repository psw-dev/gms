using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UploadFileHistoryStatusRequestDTO
    {
        [JsonPropertyName("id")]
        public long ID { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusID { get; set; }

        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }

    }
}
