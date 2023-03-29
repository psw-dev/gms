using System.Text.Json;
using PSW.GMS.Data;
using AutoMapper;
using PSW.GMS.Common.Pagination;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using PSW.Common.Crypto;
using psw.common.Extensions;
using PSW.GMS.Common;
using Microsoft.AspNetCore.Http;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Service.Command
{
    public class CommandRequest
    {
        public JsonElement data { get; set; }
        public string methodId { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public ICryptoAlgorithm CryptoAlgorithm { get; set; }
        public IMapper _mapper { get; set; }
        public ServerPaginationModel pagination { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }
        public ClaimsPrincipal CurrentUser { get; set; }
        public IFormFile file { get; set; }
        public long fileId { get; set; }
        public string roleCode { get; set; }
        // public IPCLog AuditLog { get; set; }
        public int LoggedInUserRoleID { get; set; }
        public string CurrentUserName
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "username").Value;
            }
        }
        public int AspNetUserId
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "sub").Value.ToIntOrDefault() ?? 0;
            }
        }
        public int SubscriptionId
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "subscriptionId").Value.ToIntOrDefault() ?? 0;
            }
        }
        public int AgencyId
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "agencyId").Value.ToIntOrDefault() ?? 0;
            }
        }
        public string NTN
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "ntn").Value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return CurrentUser?.Claims?.First(claim => claim.Type == "email").Value;
            }
        }

        public string SubscriptionTypeCode
        {
            get
            {
                return UserClaims?.First(claim => claim.Type == "subscriptionTypeCode").Value;
            }
        }

        private List<UserRoleDTO> _userRoles;
        public List<UserRoleDTO> UserRoles
        {
            get
            {
                if (_userRoles == null)
                {
                    var userRoleClaims = CurrentUser?.Claims?.Where(x => x.Type == "role");
                    if (userRoleClaims != null)
                    {
                        _userRoles = new List<UserRoleDTO>();
                        foreach (var userRole in userRoleClaims)
                        {
                            var userRolesDto = System.Text.Json.JsonSerializer.Deserialize<List<UserRoleDTO>>(userRole.Value);
                            _userRoles.AddRange(userRolesDto);
                        }
                    }
                }

                return _userRoles;
            }
            set => _userRoles = value;
        }
        public int ParentUserRoleID
        {

            get
            {
                return UserClaims?.First(claim => claim.Type == "parentUserRoleID").Value.ToIntOrDefault() ?? 0;
            }

        }
    }
}