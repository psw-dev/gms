using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetGuaranteeHistoryDTO
    {
        [JsonPropertyName("guaranteeID")]
        public long GuaranteeID { get; set; }
    }
}