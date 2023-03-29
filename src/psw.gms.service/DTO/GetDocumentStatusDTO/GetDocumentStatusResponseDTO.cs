using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GetDocumentStatusResponseDTO

    {

        [JsonPropertyName("statusID")]
        public int StatusID { get; set; }

    }

}