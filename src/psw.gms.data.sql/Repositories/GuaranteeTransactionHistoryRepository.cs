using System.Data;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class GuaranteeTransactionHistoryRepository : Repository<GuaranteeTransactionHistory>, IGuaranteeTransactionHistoryRepository
    {
        #region public constructors

        public GuaranteeTransactionHistoryRepository(IDbConnection connection) : base(connection)
        {
            TableName = "[dbo].[GuaranteeTransactionHistory]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods

        #endregion
    }
}