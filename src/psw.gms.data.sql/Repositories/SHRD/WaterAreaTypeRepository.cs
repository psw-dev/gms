using System.Data;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class WaterAreaTypeRepository : Repository<WaterAreaType>, IWaterAreaTypeRepository
    {
        #region public constructors

        public WaterAreaTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[WaterAreaType]";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}