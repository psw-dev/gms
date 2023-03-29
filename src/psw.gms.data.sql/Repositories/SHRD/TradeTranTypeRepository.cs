/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;

using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class TradeTranTypeRepository : Repository<TradeTranType>, ITradeTranTypeRepository
    {
		#region public constructors

        public TradeTranTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[dbo].[TradeTranType]";
			PrimaryKeyName = "ID";
        }

		#endregion

		#region Public methods

		#endregion
    }
}
