/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Data;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class AllowedDocumentReviewCountRepository : Repository<AllowedDocumentReviewCount>, IAllowedDocumentReviewCountRepository
    {
        #region public constructors

        public AllowedDocumentReviewCountRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[AllowedDocumentReviewCount]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods

        #endregion
    }
}
