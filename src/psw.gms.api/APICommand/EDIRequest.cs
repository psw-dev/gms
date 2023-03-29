using System.Text.Json;
using PSW.GMS.Common.Pagination;

namespace PSW.GMS.Api.ApiCommand
{
    public class EDIRequest
    {
        public string methodId { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
        public ServerPaginationModel pagination { get; set; }
        public string senderId { get; set; }
        public string receiverId { get; set; }
        public string messageId { get; set; }
        public string timestamp { get; set; }
    }
}