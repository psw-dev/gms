using System;
using PSW.Lib.Logs;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.BusinessLogicLayer;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.ModelValidators;
using PSW.GMS.Service.Helpers;

namespace PSW.GMS.Service.Strategies
{
    public class UpdateGuaranteeTransactionStrategy : ApiStrategy<UpdateGuaranteeTransactionRequestDTO, UpdateGuaranteeTransactionResponseDTO>
    {

        public UpdateGuaranteeTransactionStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
            this.Validator = new UpdateGuaranteeTransactionRequestDTOValidator();
        }

        public override CommandReply Execute()
        {
            try
            {
                Log.Information("|{0}|{1}| Request DTO {@RequestDTO}", StrategyName, MethodID, RequestDTO);
                var currentRole = StrategyHelper.GetCurrentUserRole(Command.UserClaims, RequestDTO.RoleCode);
                if (currentRole == null)
                    return BadRequestReply("Invalid user role");

                var gurTransHistoryEntity = MapElements();

                var guaranteeBLL = new GuaranteeBLL(Command.UnitOfWork);
                int ret = guaranteeBLL.validateUpdateTransactionRequest(RequestDTO, Command.SubscriptionId, Command.LoggedInUserRoleID, Command.ParentUserRoleID, currentRole.UserRoleID, Command.CryptoAlgorithm.Decrypt(RequestDTO.AgentParentCollectorateCode), out var responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }

                ret = guaranteeBLL.UpdateGuaranteeTransaction(RequestDTO, ref gurTransHistoryEntity, out responseMessage);
                if (ret != 0)
                {
                    return BadRequestReply(responseMessage);
                }
                else
                {
                    ResponseDTO = Mapper.Map<UpdateGuaranteeTransactionResponseDTO>(gurTransHistoryEntity);
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

        private GuaranteeTransactionHistory MapElements()
        {
            var gurTransHistory = Mapper.Map<GuaranteeTransactionHistory>(RequestDTO);

            if (gurTransHistory.GuaranteeTransactionStatusID == GuaranteeTransactionStatus.Approved)
            {
                gurTransHistory.ApprovedOn = DateTime.Now;
            }
            else
            {
                gurTransHistory.RejectedOn = DateTime.Now;
            }

            // Not null columns of GURTransHistory
            gurTransHistory.SoftDelete = false;
            gurTransHistory.CreatedOn = DateTime.Now;
            gurTransHistory.UpdatedOn = DateTime.Now;
            gurTransHistory.CreatedBy = Command.LoggedInUserRoleID;
            gurTransHistory.UpdatedBy = Command.LoggedInUserRoleID;
            return gurTransHistory;
        }
    }
}