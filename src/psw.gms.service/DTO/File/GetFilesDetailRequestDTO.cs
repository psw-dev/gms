using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetFilesDetailRequestDTO
    {
        [JsonPropertyName("files")]
        public List<string> Files { get; set; }
    }
}