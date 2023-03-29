using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class DocumentAssigneeInfoResponseDTO
    {

        [JsonPropertyName("isPermitted")]
        public bool IsPermitted { get; set; }

        [JsonPropertyName("isNotAssigned")]
        public bool IsNotAssigned { get; set; }

        [JsonPropertyName("name")]
        public string PersonName { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; }

        [JsonPropertyName("roleID")]
        public int RoleID { get; set; }

        [JsonPropertyName("documentID")]
        public long DocumentID { get; set; }

    }
}