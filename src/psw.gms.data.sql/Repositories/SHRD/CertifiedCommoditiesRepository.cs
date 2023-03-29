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
    public class CertifiedCommoditiesRepository : Repository<CertifiedCommodities>, ICertifiedCommoditiesRepository
    {
        #region public constructors

        public CertifiedCommoditiesRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[CertifiedCommodities]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods

        public CertifiedCommodities GetCertifiedCommodity(short commodityCertificateId)
        {
            return _connection.QueryFirstOrDefault<CertifiedCommodities>(
                @"SELECT * FROM shrd.dbo.CertifiedCommodities WHERE ID = @COMMODITYCERTIFICATEID",
                param: new
                {
                    COMMODITYCERTIFICATEID = commodityCertificateId
                }, transaction: _transaction);
        }

        #endregion
    }
}