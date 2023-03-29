/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class RefShedLocationsRepository : Repository<RefShedLocations>, IRefShedLocationsRepository
    {
        #region public constructors

        public RefShedLocationsRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Ref_Shed_Locations]";
            PrimaryKeyName = "Shed_Location_ID";
        }
        public string GetShedName(long id)
        {
            return _connection.QueryFirstOrDefault<string>(
                    @"SELECT shed_name 
                        FROM   [SHRD].[dbo].[ref_shed_locations] 
                        WHERE  shed_location_id = @REQUESTID ;",
                    param: new { REQUESTID = id },
                    transaction: _transaction
                    );
        }
        #endregion

        #region Public methods

        #endregion
    }
}
