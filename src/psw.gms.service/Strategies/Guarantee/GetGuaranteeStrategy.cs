using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.ModelValidators;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.Lib.Logs;
using System.Collections.Generic;
using PSW.GMS.Service.Helpers;
using PSW.GMS.Common.Constants;

namespace PSW.GMS.Service.Strategies
{
    public class GetGuaranteeStrategy : ApiStrategy<GetGuaranteeRequestDTO, List<GetGuaranteeResponseDTO>>
    {

        public GetGuaranteeStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
            this.Validator = new GetGuaranteeRequestDTOValidator();
        }

        public override CommandReply Execute()
        {
            try
            {
                Log.Information("|{0}|{1}| Request DTO {@RequestDTO}", StrategyName, MethodID, RequestDTO);
                var currentRole = StrategyHelper.GetCurrentUserRole(Command.UserClaims, RequestDTO.RoleCode);
                if (currentRole == null || (currentRole.RoleCode != RoleCode.TRADER && currentRole.RoleCode != RoleCode.CUSTOM_AGENT))
                    return BadRequestReply("Invalid user role");

                var guaranteeBLL = new GuaranteeBLL(Command.UnitOfWork);
                int ret = guaranteeBLL.Get(RequestDTO, Command.SubscriptionId, Command.LoggedInUserRoleID, Command.ParentUserRoleID, currentRole.UserRoleID, Command.CryptoAlgorithm.Decrypt(RequestDTO.AgentParentCollectorateCode), out var guaranteeList, out var responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }
                else
                {
                    List<GetGuaranteeResponseDTO> response = new List<GetGuaranteeResponseDTO>();
                    foreach (var guarantee in guaranteeList)
                    {
                        var newDTO = Mapper.Map<GetGuaranteeResponseDTO>(guarantee);
                        response.Add(newDTO);
                    }
                    ResponseDTO = response;
                    Log.Information("|{0}|{1}| Sending response {@ResponseDTO}", StrategyName, MethodID, ResponseDTO);
                    return OKReply(responseMessage);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("|{0}|{1}| System exception caught: {2}", StrategyName, MethodID, ex.Message);
                return InternalServerErrorReply(ex, "Internal Error");
            }
        }
    }
}