using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetFileBytesRequestDTO
    {
        [JsonPropertyName("fileId")]
        public long FileId { get; set; }
    }
}