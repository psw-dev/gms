using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using PSW.GMS.Api.ApiCommand;
using PSW.GMS.Service;
using PSW.GMS.Service.Strategies;
using PSW.GMS.Service.Exceptions;
using PSW.GMS.Data;
using PSW.GMS.Service.Command;
using System.Security.Cryptography;

namespace PSW.GMS.Api.Controllers
{

    [Route("api/v1/gms/[controller]")]
    [ApiController]
    public class TestController
    {


        [HttpPost("secure")]
        public ActionResult<APIResponse> SecureRequest(APIRequest apiRequest)
        {
            return new APIResponse();
        }


        [HttpPost("open")]
        public ActionResult<object> OpenRequest(APIRequest apiRequest)
        {
            return new APIResponse();
        }


        [HttpPost("test")]
        public string test(APIRequest apiRequest)
        {
            return "Hello";
        }


    }
}