using Microsoft.AspNetCore.Mvc;
using PSW.GMS.Api.ApiCommand;
using PSW.GMS.Service;
using PSW.GMS.Data;
using Microsoft.AspNetCore.Authorization;
using PSW.Common.Crypto;
using PSW.GMS.Api.Controllers;
using Microsoft.AspNetCore.Http;

namespace PSW.GMS.Api.Controllers
{
    [Route("api/v1/gms/[controller]")]
    [ApiController]
    public class EDIWebocController : BaseController
    {
        #region Constructors

        public EDIWebocController(IGmsSecureService secureService, IGmsOpenService openService, IUnitOfWork uow, ICryptoAlgorithm cryptoAlgorithm, IHttpContextAccessor httpContextAccessor)
            : base(secureService, openService, uow, cryptoAlgorithm, httpContextAccessor)
        {
        }

        #endregion

        #region End Points 

        [HttpPost("secure")]
        [Authorize("authWeBoCPolicy")]
        public override ActionResult<APIResponse> SecureRequest(APIRequest apiRequest)
        {
            return base.SecureRequest(apiRequest);
        }

        [HttpPost("open")]
        public override ActionResult<object> OpenRequest(APIRequest apiRequest)
        {
            return base.OpenRequest(apiRequest);
        }

        [HttpGet("query/{methodId}")]
        public override ActionResult<object> OpenRequest(string methodId, string username, int duration)
        {
            return base.OpenRequest(methodId, username, duration);
        }

        [HttpGet("version")]
        public override ActionResult<object> GetVersion()
        {
            return "20210219_144630";
        }

        [HttpGet("env")]
        public ActionResult<object> GetEnv()
        {
            return System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        #endregion
    }
}