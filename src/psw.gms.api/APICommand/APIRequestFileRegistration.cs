using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PSW.GMS.Common.Pagination;

namespace PSW.GMS.Api.ApiCommand
{
    public class APIRequestFileRegistration
    {
        public string methodId { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
        public ServerPaginationModel pagination { get; set; }
        public IFormFile file { get; set; }
        public string FilePath { get; set; }
        public string DocumentClassificationCode { get; set; }
        public string RequestDocumentTypeCode { get; set; }
        public int AgencyID { get; set; }
        public long fileId { get; set; }
        public string roleCode { get; set; }
    }

    public class Data
    {
        public string filepath { get; set; }
        public string documentClassificationCode { get; set; }
        public string requestDocumentTypeCode { get; set; }
        public int agencyID { get; set; }
        public long fileId { get; set; }
        public string roleCode { get; set; }
    }
}