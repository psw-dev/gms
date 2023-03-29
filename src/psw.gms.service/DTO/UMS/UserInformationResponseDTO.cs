using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UserInformationResponseDTO
    {
        [JsonPropertyName("personName")]
        public string PersonName { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("userRoleName")]
        public string UserRoleName { get; set; }

        [JsonPropertyName("cities")]
        public IEnumerable<string> Cities { get; set; }

        [JsonPropertyName("signaturePictureFileID")]
        public string SignaturePictureFileID { get; set; }
    }
}