using System.Text.Json;

namespace PSW.GMS.Service.DTO.EDI
{
    public class ThirdPartyResponseDTO
    {
        public string messageId { get; set; }
        public string timestamp { get; set; }
        public string senderId { get; set; }
        public string receiverId { get; set; }
        public string processingCode { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
        public ResponseMessage message { get; set; }
    }
    public class ResponseMessage
    {
        public string code { get; set; }
        public string description { set; get; }
    }
}