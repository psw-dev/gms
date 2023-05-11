using System;
using System.Collections.Generic;
using System.Linq;
using PSW.Lib.Logs;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.BusinessLogicLayer
{
    public class GuaranteeBLL : IDocument
    {
        public string BLLName { get; set; }
        private const string DOC_IDENTIFIER = "GUR";
        public IUnitOfWork UnitOfWork { get; set; }
        const string GUR_NUMBER_DATE_FORMAT = "ddMMyyyy";
        const string DATE_FORMAT = "yyyyMMdd";

        public GuaranteeBLL(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.BLLName = GetType().Name;
        }

        public int Create(ref Guarantee gurEntity, out string responseMessage)
        {
            try
            {
                var gurNumber = GetDocNumber();
                if (gurNumber != null)
                {
                    gurEntity.ReferenceNumber = gurNumber;
                }

                // Begin transaction
                UnitOfWork.BeginTransaction();

                Log.Debug("|{0}| Inserting Guarantee {@Guarantee} in database", BLLName, gurEntity);
                var gurId = UnitOfWork.GuaranteeRepository.Add(gurEntity);

                UnitOfWork.Commit();

                responseMessage = "Guarantee inserted successfully!";
                gurEntity.ID = gurId;
                return 0;
            }
            catch (System.Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        public int Get(GetGuaranteeRequestDTO requestDTO, int subscriptionID, int userRoleId
        , int parentRoleID, int loggedInUserRoleId, string parentCollectorateCode
        , out IEnumerable<Guarantee> guaranteeList, out string responseMessage)
        {
            try
            {
                if (requestDTO.RoleCode == RoleCode.CUSTOM_AGENT
                && requestDTO.AgentParentCollectorateCode == null)
                {
                    responseMessage = "AgentParentCollectorateCode is required for Custom Agent!";
                    guaranteeList = new List<Guarantee>();
                    return -1;
                }
                else if (requestDTO.RoleCode == RoleCode.TRADER && requestDTO.TraderNTN == null)
                {
                    guaranteeList = new List<Guarantee>();
                    responseMessage = "TraderNTN is required for Trader!";
                    return -1;
                }

                if (requestDTO.ID > 0)
                {
                    guaranteeList = UnitOfWork.GuaranteeRepository
                    .Where(new { ID = requestDTO.ID, SoftDelete = false });
                    if (guaranteeList.Count() > 0)
                    {
                        var guarantee = guaranteeList.FirstOrDefault();

                        if (guarantee.TraderNTN != requestDTO.TraderNTN)
                        {
                            responseMessage = "TraderNTN does not match!";
                            return -1;
                        }

                        if (requestDTO.RoleCode == RoleCode.TRADER)
                        {
                            if (guarantee.TraderSubscriptionID != subscriptionID)
                            {
                                responseMessage = "TraderSubscriptionID does not match!";
                                return -1;
                            }
                            if (parentRoleID > 0 && loggedInUserRoleId > 0
                            && guarantee.TraderRoleID != userRoleId)
                            {
                                responseMessage = "TraderRoleID does not match!";
                                return -1;
                            }
                        }
                        else if (requestDTO.RoleCode == RoleCode.CUSTOM_AGENT)
                        {
                            if (guarantee.AgentSubscriptionID != subscriptionID)
                            {
                                responseMessage = "AgentSubscriptionID does not match!";
                                return -1;
                            }
                            if (guarantee.AgentParentCollectorateCode != parentCollectorateCode)
                            {
                                responseMessage = "ParentCollectorateCode does not match!";
                                return -1;
                            }
                            if (parentRoleID > 0 && loggedInUserRoleId > 0
                            && guarantee.AgentRoleID != userRoleId)
                            {
                                responseMessage = "AgentRoleID does not match!";
                                return -1;
                            }
                        }
                    }
                }
                else
                {
                    if (requestDTO.RoleCode == RoleCode.TRADER)
                    {
                        if (parentRoleID > 0 && loggedInUserRoleId > 0)
                        {
                            guaranteeList = UnitOfWork.GuaranteeRepository
                            .Where(new
                            {
                                TraderNTN = requestDTO.TraderNTN,
                                TraderRoleID = userRoleId,
                                TraderSubscriptionID = subscriptionID,
                                SoftDelete = false
                            });
                        }
                        else
                        {
                            guaranteeList = UnitOfWork.GuaranteeRepository
                            .Where(new
                            {
                                TraderNTN = requestDTO.TraderNTN,
                                TraderSubscriptionID = subscriptionID,
                                SoftDelete = false
                            });
                        }
                    }
                    else
                    {
                        if (parentRoleID > 0 && loggedInUserRoleId > 0)
                        {
                            if (requestDTO.TraderNTN == null)
                            {
                                guaranteeList = UnitOfWork.GuaranteeRepository
                                .Where(new
                                {
                                    AgentSubscriptionID = subscriptionID,
                                    AgentParentCollectorateCode = parentCollectorateCode,
                                    AgentRoleID = userRoleId,
                                    SoftDelete = false
                                });
                            }
                            else
                            {
                                guaranteeList = UnitOfWork.GuaranteeRepository
                                .Where(new
                                {
                                    TraderNTN = requestDTO.TraderNTN,
                                    AgentSubscriptionID = subscriptionID,
                                    AgentParentCollectorateCode = parentCollectorateCode,
                                    AgentRoleID = userRoleId,
                                    SoftDelete = false
                                });
                            }
                        }
                        else
                        {
                            if (requestDTO.TraderNTN == null)
                            {
                                guaranteeList = UnitOfWork.GuaranteeRepository
                                .Where(new
                                {
                                    AgentSubscriptionID = subscriptionID,
                                    AgentParentCollectorateCode = parentCollectorateCode,
                                    SoftDelete = false
                                });
                            }
                            else
                            {
                                guaranteeList = UnitOfWork.GuaranteeRepository
                                .Where(new
                                {
                                    TraderNTN = requestDTO.TraderNTN,
                                    AgentSubscriptionID = subscriptionID,
                                    AgentParentCollectorateCode = parentCollectorateCode,
                                    SoftDelete = false
                                });
                            }
                        }
                    }
                }

                if (guaranteeList.Count() > 0)
                    responseMessage = "Guarantee(s) fetched successfully!";
                else
                    responseMessage = "No Guarantee found!";
                Log.Debug("|{0}| Retrieving {1} Guarantee(s) from database", BLLName, guaranteeList.Count());
                return 0;
            }
            catch (System.Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        public int Update(Guarantee gurEntity, out string responseMessage)
        {
            var gur = UnitOfWork.GuaranteeRepository.Update(gurEntity);
            Log.Debug("|{0}| Updated Guarantee with Balance Amount {1} in database", BLLName, gurEntity.BalanceAmount);
            responseMessage = "Guarantee Updated";
            return 0;
        }

        public int Delete(long ID, out string responseMessage)
        {
            responseMessage = "";
            return 0;
        }

        public string GetDocNumber()
        {
            var currentDate = DateTime.Now;
            var gurNumberCount = UnitOfWork.GuaranteeRepository.GetCountForGURNumber();
            if (!string.IsNullOrEmpty(gurNumberCount))
            {
                var gurCount = string.Empty;
                //Date in counter
                var dateInCount = gurNumberCount.Substring(0, 8);
                var parsedDate = DateTime.ParseExact(dateInCount, DATE_FORMAT, null);

                if (currentDate < parsedDate)
                    gurCount = gurNumberCount.Substring(gurNumberCount.Length - 5);
                else
                {
                    gurNumberCount = UnitOfWork.GuaranteeRepository.RestartCounterForGURNumber(DATE_FORMAT);
                    gurCount = gurNumberCount.Substring(gurNumberCount.Length - 5);
                }
                return string.Format($"{DOC_IDENTIFIER}-{gurCount}-{currentDate.ToString(GUR_NUMBER_DATE_FORMAT)}");
            }
            return string.Empty;
        }

        public int UpdateGuaranteeTransaction(long guaranteeID
        , ref GuaranteeTransactionHistory gurTransHistory, out string responseMessage)
        {
            try
            {
                // Begin transaction
                UnitOfWork.BeginTransaction();

                Log.Debug("|{0}| Inserting GuaranteeTransactionHistory {@GuaranteeTransactionHistory} in database", BLLName, gurTransHistory);
                int gurTransId = UnitOfWork.GuaranteeTransactionHistoryRepository.Add(gurTransHistory);

                if (gurTransId > 0
                && gurTransHistory.GuaranteeTransactionStatusID == GuaranteeTransactionStatus.Approved)
                {
                    var guarantee = UnitOfWork.GuaranteeRepository
                    .Where(new { ID = guaranteeID, SoftDelete = false })
                    .FirstOrDefault();
                    guarantee.BalanceAmount -= gurTransHistory.ConsumedAmount.Value;
                    guarantee.UpdatedBy = gurTransHistory.UpdatedBy;
                    guarantee.UpdatedOn = gurTransHistory.UpdatedOn;
                    Update(guarantee, out responseMessage);
                }

                UnitOfWork.Commit();

                responseMessage = "Guarantee Transaction Added successfully!";
                gurTransHistory.ID = gurTransId;
                return 0;
            }
            catch (System.Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        public int GetGuaranteeHistory(long guaranteeID, out IEnumerable<Entity> transactions
        , out string responseMessage)
        {
            try
            {
                transactions = UnitOfWork.GuaranteeTransactionHistoryRepository
                .Where(new { GuaranteeID = guaranteeID, SoftDelete = false });

                if (transactions.Count() > 0)
                    responseMessage = "Guarantee history fetched successfully!";
                else
                    responseMessage = "No guarantee history found!";
                Log.Debug("|{0}| Retrieved {1} Guarantee transaction(s) from database", BLLName, transactions.Count());
                return 0;
            }
            catch (System.Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        public int validateCreateRequest(string roleCode, Guarantee gurEntity, out string responseMessage)
        {
            var guarantee = UnitOfWork.GuaranteeRepository
            .Where(new { GuaranteeNumber = gurEntity.GuaranteeNumber, SoftDelete = false })
            .FirstOrDefault();

            if (guarantee != null)
            {
                responseMessage = "Guarantee Number already exists!";
                return -1;
            }
            if (gurEntity.TotalAmount <= 0)
            {
                responseMessage = "Total amount can not be zero or less!";
                return -1;
            }
            if (gurEntity.ExpiryDate <= DateTime.Now)
            {
                responseMessage = "Guarantee already expired!";
                return -1;
            }
            if (gurEntity.IssueDate > DateTime.Now)
            {
                responseMessage = "Invalid Issue date!";
                return -1;
            }
            if (roleCode == RoleCode.CUSTOM_AGENT)
            {
                if (gurEntity.TraderSubscriptionID <= 0)
                {
                    responseMessage = "TraderSubscriptionID required!";
                    return -1;
                }
                if (gurEntity.AgentParentCollectorateCode == null)
                {
                    responseMessage = "AgentParentCollectorateCode required!";
                    return -1;
                }
            }
            responseMessage = "";
            return 0;
        }

        public int validateUpdateTransactionRequest(UpdateGuaranteeTransactionRequestDTO requestDTO
        , int subscriptionID, int userRoleId, int parentRoleID, int loggedInUserRoleId
        , string parentCollectorateCode, out string responseMessage)
        {
            var guarantee = UnitOfWork.GuaranteeRepository
            .Where(new { ID = requestDTO.GuaranteeID, SoftDelete = false })
            .FirstOrDefault();

            if (guarantee == null)
            {
                responseMessage = "Guarantee Number does not exist!";
                return -1;
            }
            if (guarantee.TraderNTN != requestDTO.TraderNTN)
            {
                responseMessage = "TraderNTN does not match!";
                return -1;
            }

            if (requestDTO.RoleCode == RoleCode.TRADER)
            {
                if (guarantee.TraderSubscriptionID != subscriptionID)
                {
                    responseMessage = "TraderSubscriptionID does not match!";
                    return -1;
                }
                if (parentRoleID > 0 && loggedInUserRoleId > 0 && guarantee.TraderRoleID != userRoleId)
                {
                    responseMessage = "TraderRoleID does not match!";
                    return -1;
                }
            }
            else if (requestDTO.RoleCode == RoleCode.CUSTOM_AGENT)
            {
                if (requestDTO.AgentParentCollectorateCode == null
                || requestDTO.AgentParentCollectorateCode == "")
                {
                    responseMessage = "AgentParentCollectorateCode required!";
                    return -1;
                }

                if (guarantee.AgentSubscriptionID != subscriptionID)
                {
                    responseMessage = "AgentSubscriptionID does not match!";
                    return -1;
                }
                if (guarantee.AgentParentCollectorateCode != parentCollectorateCode)
                {
                    responseMessage = "AgentParentCollectorateCode does not match!";
                    return -1;
                }
                if (parentRoleID > 0 && loggedInUserRoleId > 0 && guarantee.AgentRoleID != userRoleId)
                {
                    responseMessage = "AgentRoleID does not match!";
                    return -1;
                }
            }

            if (requestDTO.GuaranteeTransactionStatusID == GuaranteeTransactionStatus.Approved)
            {
                if (requestDTO.ConsumedAmount == null || requestDTO.ConsumedAmount <= 0)
                {
                    responseMessage = "Consumed amount required for approval!";
                    return -1;
                }
                if (requestDTO.ConsumedAmount > guarantee.BalanceAmount)
                {
                    responseMessage = "Consumed amount exceeds Guarantee balance amount!";
                    return -1;
                }
            }
            responseMessage = "";
            return 0;
        }

        public int validateGetHistoryRequest(GetGuaranteeHistoryRequestDTO requestDTO, int subscriptionID
        , int userRoleId, int parentRoleID, int loggedInUserRoleId, string parentCollectorateCode
        , out string responseMessage)
        {
            var guarantee = UnitOfWork.GuaranteeRepository
            .Where(new { ID = requestDTO.GuaranteeID, SoftDelete = false })
            .FirstOrDefault();

            if (guarantee == null)
            {
                responseMessage = "Guarantee Number does not exist!";
                return -1;
            }
            if (guarantee.TraderNTN != requestDTO.TraderNTN)
            {
                responseMessage = "TraderNTN does not match!";
                return -1;
            }

            if (requestDTO.RoleCode == RoleCode.TRADER)
            {
                if (guarantee.TraderSubscriptionID != subscriptionID)
                {
                    responseMessage = "TraderSubscriptionID does not match!";
                    return -1;
                }
                if (parentRoleID > 0 && loggedInUserRoleId > 0 && guarantee.TraderRoleID != userRoleId)
                {
                    responseMessage = "TraderRoleID does not match!";
                    return -1;
                }
            }
            else if (requestDTO.RoleCode == RoleCode.CUSTOM_AGENT)
            {
                if (requestDTO.AgentParentCollectorateCode == null
                || requestDTO.AgentParentCollectorateCode == "")
                {
                    responseMessage = "AgentParentCollectorateCode required!";
                    return -1;
                }

                if (guarantee.AgentSubscriptionID != subscriptionID)
                {
                    responseMessage = "AgentSubscriptionID does not match!";
                    return -1;
                }
                if (guarantee.AgentParentCollectorateCode != parentCollectorateCode)
                {
                    responseMessage = "ParentCollectorateCode does not match!";
                    return -1;
                }
                if (parentRoleID > 0 && loggedInUserRoleId > 0 && guarantee.AgentRoleID != userRoleId)
                {
                    responseMessage = "AgentRoleID does not match!";
                    return -1;
                }
            }
            responseMessage = "";
            return 0;
        }
    }
}