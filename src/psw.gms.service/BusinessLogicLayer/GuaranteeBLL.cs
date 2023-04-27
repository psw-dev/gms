using System;
using System.Collections.Generic;
using System.Linq;
using PSW.GMS.Data;
using PSW.GMS.Data.Entities;
using PSW.Lib.Logs;

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

        public int validate(Guarantee gurEntity, ref string responseMessage)
        {
            var guarantee = UnitOfWork.GuaranteeRepository
            .Where(new { GuaranteeNumber = gurEntity.GuaranteeNumber, SoftDelete = false })
            .FirstOrDefault();

            if (guarantee != null)
            {
                responseMessage = "Guarantee Number already exists!";
                return -1;
            }
            else if (gurEntity.TotalAmount <= 0)
            {
                responseMessage = "Total amount can not be zero or less!";
                return -1;
            }
            else if (gurEntity.ExpiryDate <= DateTime.Now)
            {
                responseMessage = "Guarantee already expired!";
                return -1;
            }
            else if (gurEntity.IssueDate > DateTime.Now)
            {
                responseMessage = "Invalid Issue date!";
                return -1;
            }
            return 0;
        }

        public int Create(ref Guarantee gurEntity, ref string responseMessage)
        {
            try
            {
                if (validate(gurEntity, ref responseMessage) != 0)
                {
                    return -1;
                }
                
                var gurNumber = GetDocNumber();
                if (gurNumber != null)
                {
                    gurEntity.ReferenceNumber = gurNumber;
                }
                // Begin transaction
                UnitOfWork.BeginTransaction();

                Log.Debug("|{0}| Inserting Guarantee {@Guarantee} in database", BLLName, gurEntity);
                var gurId = UnitOfWork.GuaranteeRepository.Add(gurEntity);
                responseMessage = "Guarantee inserted successfully";

                UnitOfWork.Commit();
                gurEntity.ID = gurId;
                return 0;
            }
            catch (System.Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        public int Delete(long ID, ref string responseMessage)
        {
            return 0;
        }

        public int Update(Guarantee gurEntity, ref string responseMessage)
        {
            return 0;
        }

        public IEnumerable<Entity> Get(long ID)
        {
            return null;
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
    }
}