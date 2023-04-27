using System;
using System.Data;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class GuaranteeRepository : Repository<Guarantee>, IGuaranteeRepository
    {
        #region public constructors

        public GuaranteeRepository(IDbConnection connection) : base(connection)
        {
            TableName = "[dbo].[Guarantee]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods
        public string GetCountForGURNumber()
        {
            try
            {
                return _connection.ExecuteScalar<string>("SELECT NEXT VALUE FOR GURNumber", transaction: _transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RestartCounterForGURNumber(string dateFormat)
        {
            var fiscalYear = (DateTime.Now.Month >= 7) ? DateTime.Now.AddYears(1).Year : DateTime.Now.Year;

            var fiscalYearDate = new DateTime(fiscalYear, 07, 01);
            var dt = fiscalYearDate.ToString(dateFormat);

            var initValueForSequence = string.Format("{0}00001", dt);
            try
            {
                _connection.Query(string.Format("ALTER SEQUENCE GURNumber RESTART WITH {0}", initValueForSequence),
                transaction: _transaction);
                
                return GetCountForGURNumber();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}