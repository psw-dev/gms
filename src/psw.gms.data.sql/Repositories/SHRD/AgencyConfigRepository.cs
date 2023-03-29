using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;
using System.Data;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class AgencyConfigRepository : Repository<AgencyConfig>, IAgencyConfigRepository
    {
        #region public constructors

        public AgencyConfigRepository(IDbConnection connection) : base(connection)
        {
            TableName = "SHRD.[dbo].[AgencyConfig]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods

        #endregion
    }
}