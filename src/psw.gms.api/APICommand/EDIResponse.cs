using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PSW.GMS.Common.Pagination;


namespace PSW.GMS.Api.ApiCommand
{
    public class EDIResponse
    {
        public string methodId { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
        public ServerPaginationModel pagination { get; set; }
        public ResponseMessage message { get; set; }
        public ErrorModel error { get; set; }
        public string senderId { get; set; }
        public string receiverId { get; set; }
        public string messageId { get; set; }
        public string timestamp { get; set; }

        public EDIResponse()
        {

        }

    }
}