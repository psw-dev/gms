/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class PortRepository : Repository<Port>, IPortRepository
    {
        #region public constructors

        public PortRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Port]";
            PrimaryKeyName = "ID";
        }
       
        #endregion

        #region Public methods

        #endregion
    }
}
