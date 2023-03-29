using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class NotificationRequestDTO
    {
        [JsonPropertyName("recepient")]
        public string Recepient { get; set; }

        [JsonPropertyName("channelID")]
        public int ChannelID { get; set; }

        [JsonPropertyName("templateID")]
        public int TemplateID { get; set; }

        [JsonPropertyName("placeholders")]
        public Dictionary<string, string> Placeholders { get; set; }

    }
}
