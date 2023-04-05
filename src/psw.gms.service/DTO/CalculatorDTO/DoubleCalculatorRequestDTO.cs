using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class DoubleCalculatorRequestDTO
    {
        [JsonPropertyName("a")]
        public double a { get; set; }

        [JsonPropertyName("b")]
        public double b { get; set; }
    }
}
