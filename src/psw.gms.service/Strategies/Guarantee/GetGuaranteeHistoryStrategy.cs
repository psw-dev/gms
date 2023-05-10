using System.Collections.Generic;
using PSW.Lib.Logs;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.ModelValidators;
using PSW.GMS.Service.Helpers;

namespace PSW.GMS.Service.Strategies
{
    public class GetGuaranteeHistoryStrategy : ApiStrategy<GetGuaranteeHistoryRequestDTO, List<GetGuaranteeHistoryResponseDTO>>
    {

        public GetGuaranteeHistoryStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
            this.Validator = new GetGuaranteeHistoryRequestDTOValidator();
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
                int ret = guaranteeBLL.validateGetHistoryRequest(RequestDTO, Command.SubscriptionId, Command.LoggedInUserRoleID, Command.ParentUserRoleID, currentRole.UserRoleID, Command.CryptoAlgorithm.Decrypt(RequestDTO.AgentParentCollectorateCode), out var responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }

                ret = guaranteeBLL.GetGuaranteeHistory(RequestDTO, out var guaranteeHistory, out responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }
                else
                {
                    List<GetGuaranteeHistoryResponseDTO> response = new List<GetGuaranteeHistoryResponseDTO>();
                    foreach (var transaction in guaranteeHistory)
                    {
                        var newDTO = Mapper.Map<GetGuaranteeHistoryResponseDTO>(transaction);
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