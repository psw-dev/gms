using PSW.GMS.Service.Command;
using System.Security.Claims;
using System.Collections.Generic;

namespace PSW.GMS.Service
{
    public interface IGmsSecureService : IService
    {
        // CommandReply invokeMethod(CommandRequest request);
        IEnumerable<Claim> UserClaims { get; set; }
    }

}