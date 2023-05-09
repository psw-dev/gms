using System.Text.Json;
using PSW.GMS.Common.Pagination;

namespace PSW.GMS.Api.ApiCommand
{
    public class APIRequest
    {
        public string methodId { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
        public ServerPaginationModel pagination { get; set; }

    }
}