/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;

using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class RefUnitsRepository : Repository<RefUnits>, IRefUnitsRepository
    {
        #region public constructors

        public RefUnitsRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Ref_Units]";
            PrimaryKeyName = "Unit_ID";
        }

        #endregion

        #region Public methods

        #endregion
    }
}
