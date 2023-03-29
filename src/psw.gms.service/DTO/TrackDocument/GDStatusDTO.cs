using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class GDInfoResponseDTO
    {

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("data")]
        public GDInfo Data { get; set; }

    }

    public class GDInfo
    {
        [JsonPropertyName("gD_Status_ID")]
        public int GDStatusID { get; set; }

        [JsonPropertyName("gD_Status")]
        public string GDStatus { get; set; }

        [JsonPropertyName("gD_No_Complete")]
        public string GDNumber { get; set; }
    }

    public class GDStatusRequestDTO
    {
        [JsonPropertyName("PSW_Tracking_ID")]
        public long SDID { get; set; }

        [JsonPropertyName("tracking_ID")]
        public long WebocGDID { get; set; }
    }

    public class GDinfoRequestDTO
    {
        public long SDID { get; set; }
        public long WebocGDID { get; set; }
        public string SDDocumentNumber { get; set; }
        public string DocumentTypeCode { get; set; }
        public string RequestDocumentNumber { get; set; }
    }
}
