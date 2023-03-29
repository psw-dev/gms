/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class TreatmentTypeRepository : Repository<TreatmentType>, ITreatmentTypeRepository
    {
        #region public constructors

        public TreatmentTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[TreatmentType]";
            PrimaryKeyName = "ID";
        }
        public string GetTeatTypeName(long id)
        {
            return _connection.QueryFirstOrDefault<string>(
                    @"SELECT name FROM shrd.dbo.TreatmentType WHERE ID = @REQUESTID;",
                    param: new { REQUESTID = id },
                    transaction: _transaction
                    );
        }

        #endregion

        #region Public methods

        #endregion
    }
}
