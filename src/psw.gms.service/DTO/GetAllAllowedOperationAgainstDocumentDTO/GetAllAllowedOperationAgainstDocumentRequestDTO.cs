using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetAllAllowedOperationAgainstDocumentRequestDTO
    {
        [JsonPropertyName("operation")]
        public int Operation { get; set; }
    }
}