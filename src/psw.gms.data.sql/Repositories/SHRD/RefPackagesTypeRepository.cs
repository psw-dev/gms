/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class RefPackagesTypeRepository : Repository<RefPackagesType>, IRefPackagesTypeRepository
    {
        #region public constructors

        public RefPackagesTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Ref_Packages_Type]";
            PrimaryKeyName = "Package_Type_ID";
        }
        // public List<Packages> GetPackages(List<long> ids)
        // {
        //     return _connection.Query<Packages>(
        //             @"SELECT package_type_id AS PackageTypeId, 
        //                      description     AS Name 
        //                 FROM   shrd.dbo.ref_packages_type 
        //                 WHERE  package_type_id IN @requestids ;",
        //             param: new { REQUESTIDS = ids },
        //             transaction: _transaction
        //             ).ToList();
        // }
        #endregion

        #region Public methods

        #endregion
    }
}
