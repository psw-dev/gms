using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using psw.common.Model;
using System.Text.Json;

namespace PSW.GMS.Service.Helpers
{
    public class StrategyHelper
    {

        /// <summary>
        ///     Return user role entity where role code matches with role in claims otherwise return null
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="roleCode"></param>
        /// <returns>UserRoleDTO</returns>
        public static UserRoleDTO GetCurrentUserRole(IEnumerable<Claim> claims, string roleCode)
        {
            var userRolesJson = claims.Where(x => x.Type == "role").ToList().FirstOrDefault().Value;
            var userRoleEntities = JsonSerializer.Deserialize<List<UserRoleDTO>>(userRolesJson);

            return userRoleEntities.FirstOrDefault(x => x.RoleCode == roleCode);
        }
    }
}