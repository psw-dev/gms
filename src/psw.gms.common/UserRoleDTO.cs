using System.Text.Json.Serialization;

namespace PSW.GMS.Common
{
    public class UserRoleDTO 
    {
        [JsonPropertyName("userRoleId")]
        public int UserRoleID { get; set; }

        [JsonPropertyName("roleCode")]
        public string RoleCode { get; set; }
    }
}