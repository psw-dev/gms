using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetTraderInformationResponseDTO
    {
        [JsonPropertyName("ntnNumber")]
        public string NTNNumber { get; set; }

        [JsonPropertyName("principleActivity")]
        public string PrincipleActivity { get; set; }

        [JsonPropertyName("totalNoOfGDsFiled")]
        public long TotalNoOfGDsFiled { get; set; }

        [JsonPropertyName("physicalInspection")]
        public long PhysicalInspection { get; set; }

        // [JsonPropertyName("totalCustomValueAssessed")]
        // public string TotalCustomValueAssessed { get; set; }

        // [JsonPropertyName("averageCustomsValue")]
        // public string AverageCustomsValue { get; set; }

        [JsonPropertyName("totalApprovedDocs")]
        public long TotalApprovedDocs { get; set; }

        [JsonPropertyName("totalRejectedDocs")]
        public long TotalRejectedDocs { get; set; }

        // [JsonPropertyName("totalDocsMarkedForLabReport")]
        // public string TotalGDsMarkedForLabReport { get; set; }


    }


}
