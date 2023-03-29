/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class RefCargoTypeRepository : Repository<RefCargoType>, IRefCargoTypeRepository
    {
		#region public constructors

        public RefCargoTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Ref_Cargo_Type]";
			PrimaryKeyName = "Cargo_ID";
        }
 public string GetCargoName(long id)
        {
            return _connection.QueryFirstOrDefault<string>(
                    @"SELECT Cargo_Name FROM shrd.dbo.Ref_Cargo_Type WHERE Cargo_ID = @REQUESTID;",
                    param: new { REQUESTID = id },
                    transaction: _transaction
                    );
        }

		#endregion

		#region Public methods

		#endregion
    }
}
