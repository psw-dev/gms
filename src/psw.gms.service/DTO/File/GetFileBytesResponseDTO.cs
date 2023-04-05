using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetFileBytesResponseDTO
    {
        [JsonPropertyName("fileBytes")]
        public byte[] FileBytes { get; set; }

        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }
    }
}