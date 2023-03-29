
using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO.SendInboxMessage;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;
using PSW.GMS.Service.DTO;
using PSW.Lib.Logs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using psw.common.Model;

namespace PSW.GMS.Service.Helpers
{
    public static class UserInformationHelper
    {
        public static UserRoleDTO GetUserInformaitonByRoleCode(CommandRequest cmd, string roleCode)
        {
            IEnumerable<Claim> userRoles = cmd.UserClaims.Where(x => x.Type == "role").ToList();
            List<UserRoleDTO> userRolesDtos = new List<UserRoleDTO>();

            foreach (Claim userRole in userRoles)
            {
                UserRoleDTO userRolesDto = JsonSerializer.Deserialize<UserRoleDTO>(userRole.Value);
                userRolesDtos.Add(userRolesDto);
            }

            UserRoleDTO currentRole = userRolesDtos.FirstOrDefault(x => x.RoleCode == roleCode);

            if (currentRole == null)
            {
                Log.Information("Invalid Role");
                return null;
            }

            return currentRole;
        }
    }
}