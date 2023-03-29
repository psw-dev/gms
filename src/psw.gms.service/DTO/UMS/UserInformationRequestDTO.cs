using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UserInformationRequestDTO
    {
        [JsonPropertyName("userRoleID")]
        public int? UserRoleID { get; set; }
    }
}