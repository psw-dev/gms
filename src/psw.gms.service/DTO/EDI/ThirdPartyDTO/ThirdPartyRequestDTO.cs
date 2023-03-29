using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO.EDI
{
    public class ThirdPartyRequestDTO
    {
        [JsonPropertyName("messageGuid")]
        public string messageId { get; set; }

        [JsonPropertyName("timeStamp")]
        public DateTime timeStamp { get; set; }

        [JsonPropertyName("senderId")]
        public string senderId { get; set; }

        [JsonPropertyName("receiverId")]
        public string receiverId { get; set; }

        [JsonPropertyName("methodId")]
        public string methodId { get; set; }

        [JsonPropertyName("data")]
        public JsonElement data { get; set; }

        [JsonPropertyName("signature")]
        public string signature { get; set; }
    }
}