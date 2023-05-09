using System;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.ModelValidators;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.GMS.Data.Entities;
using PSW.Lib.Logs;
using PSW.GMS.Service.Helpers;

namespace PSW.GMS.Service.Strategies
{
    public class SaveGuaranteeDocumentStrategy : ApiStrategy<SaveGuaranteeDocumentRequestDTO, SaveGuaranteeDocumentResponseDTO>
    {
        public SaveGuaranteeDocumentStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
            this.Validator = new SaveGuaranteeDocumentRequestDTOValidator();
        }

        public override CommandReply Execute()
        {
            try
            {
                Log.Information("|{0}|{1}| Request DTO {@RequestDTO}", StrategyName, MethodID, RequestDTO);
                var currentRole = StrategyHelper.GetCurrentUserRole(Command.UserClaims, RequestDTO.RoleCode);
                if (currentRole == null)
                    return BadRequestReply("Invalid user role");

                var gurEntity = MapElements();

                var guaranteeBLL = new GuaranteeBLL(Command.UnitOfWork);
                int ret = guaranteeBLL.Create(RequestDTO.RoleCode, ref gurEntity, out var responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }
                else
                {
                    ResponseDTO = Mapper.Map<SaveGuaranteeDocumentResponseDTO>(gurEntity);
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

        private Guarantee MapElements()
        {
            var GUR = Mapper.Map<Guarantee>(RequestDTO);

            // Not null columns of GUR
            GUR.GuaranteeTypeID = GuaranteeType.Bank_Guarantee;
            GUR.GuaranteeStatusID = GuaranteeStatus.Submitted;
            if (RequestDTO.RoleCode == RoleCode.CUSTOM_AGENT)
                MapCustomsAgentParams(ref GUR);

            else if (RequestDTO.RoleCode == RoleCode.TRADER)
                MapTraderParams(ref GUR);

            GUR.BalanceAmount = GUR.TotalAmount;
            GUR.SoftDelete = false;
            GUR.CreatedOn = DateTime.Now;
            GUR.UpdatedOn = DateTime.Now;
            GUR.CreatedBy = Command.LoggedInUserRoleID;
            GUR.UpdatedBy = Command.LoggedInUserRoleID;

            return GUR;
        }

        private void MapCustomsAgentParams(ref Guarantee gurEntity)
        {
            gurEntity.AgentSubscriptionID = Command.SubscriptionId;
            gurEntity.AgentRoleID = Command.LoggedInUserRoleID;
            gurEntity.AgentParentCollectorateCode = Command.CryptoAlgorithm.Decrypt(RequestDTO.AgentParentCollectorateCode);

            // Agent is creating Guarantee on behalf of trader
            gurEntity.TraderSubscriptionID = RequestDTO.TraderSubscriptionID;
        }

        private void MapTraderParams(ref Guarantee gurEntity)
        {
            gurEntity.TraderSubscriptionID = Command.SubscriptionId;
            gurEntity.TraderRoleID = Command.LoggedInUserRoleID;
        }
    }
}