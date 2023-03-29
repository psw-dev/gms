using System.Data;

using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class MeansOfConveyanaceRepository : Repository<MeansOfConveyanace>, IMeansOfConveyanaceRepository
    {
        #region public constructors

        public MeansOfConveyanaceRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[MeansOfConveyanace]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods

        #endregion
    }
}
