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
        private string role;

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
                role = currentRole.RoleCode;

                var gurEntity = MapElements();

                var guaranteeBLL = new GuaranteeBLL(Command.UnitOfWork);
                string responseMessage = "";
                int ret = guaranteeBLL.Create(ref gurEntity, ref responseMessage);
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
            if (role == RoleCode.CUSTOM_AGENT)
                MapCustomsAgentParams(ref GUR);

            else if (role == RoleCode.TRADER)
                MapTraderParams(ref GUR);

            GUR.BalanceAmount = GUR.TotalAmount;
            GUR.SoftDelete = false;
            GUR.CreatedOn = DateTime.Now;
            GUR.UpdatedOn = DateTime.Now;
            GUR.CreatedBy = Command.LoggedInUserRoleID;
            GUR.UpdatedBy = Command.LoggedInUserRoleID;
            GUR.TraderRoleID = RequestDTO.TraderRoleID;
            GUR.AgentRoleID = RequestDTO.AgentRoleID;
            
            return GUR;
        }
        
        private void MapCustomsAgentParams(ref PSW.GMS.Data.Entities.Guarantee gurEntity)
        {
            gurEntity.AgentSubscriptionID = Command.SubscriptionId;

            // Agent is filing Guarantee on behalf of trader which is consignor in export case
            gurEntity.TraderSubscriptionID = RequestDTO.TraderSubscriptionID;

        }

        private void MapTraderParams(ref PSW.GMS.Data.Entities.Guarantee gurEntity)
        {
            gurEntity.TraderSubscriptionID = Command.SubscriptionId;
        }
    }
}