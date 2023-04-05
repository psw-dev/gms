using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class IntCalculatorRequestDTO
    {
        [JsonPropertyName("a")]
        public int a { get; set; }

        [JsonPropertyName("b")]
        public int b { get; set; }
    }
}
