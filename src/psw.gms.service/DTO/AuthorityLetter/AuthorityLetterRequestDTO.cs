using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PSW.Lib.WorkFlow.DTO;

namespace PSW.GMS.Service.DTO
{
    public class AuthorityLetterRequestDTO
    {
        [JsonPropertyName("ntn")]
        public string NTN { get; set; }

        [JsonPropertyName("challNo")]
        public string ChallNo { get; set; }
    }
}