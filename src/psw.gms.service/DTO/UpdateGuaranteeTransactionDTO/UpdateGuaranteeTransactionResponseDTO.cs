using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class UpdateGuaranteeTransactionResponseDTO : UpdateGuaranteeTransactionDTO
    {
        [JsonPropertyName("iD")]
        public long ID { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("rejectedOn")]
        public DateTime? RejectedOn { get; set; }
    }
}