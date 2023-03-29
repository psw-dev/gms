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
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        #region public constructors

        public DocumentTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[dbo].[DocumentType]";
            PrimaryKeyName = "Code";
        }

        #endregion

        #region    
        public string GetCertificateTypeCode(int agencyId, string documentClassificationCode, string AltCode)
        {
            return _connection.QueryFirstOrDefault<string>(@"
                SELECT Code 
                FROM SHRD.dbo.DocumentType
                WHERE agencyID = @AGENCYID AND DocumentClassificationCode = @DOCUMENTTYPECODE AND AltCode = @ALTCODE",
                param: new
             {
                 AGENCYID = agencyId,
                 DOCUMENTTYPECODE = documentClassificationCode,
                 ALTCODE = AltCode
             }, transaction: _transaction);
        }

        // public List<RegistrationTypes> GetRegistrationTypes(long agencyId)
        // {
        //     return _connection.Query<RegistrationTypes>(
        //             @"SELECT RT.Name,
        //                      RT.DocumentClassificationCode,
        //                      ART.IsActive 
        //                 FROM [SHRD].dbo.[AgencyRegistrationType] ART
        //                 JOIN  [SHRD].dbo.[RegistrationType] RT ON ART.RegistrationTypeID = RT.ID
        //                 WHERE ART.AgencyID = @AGENCYID ;",
        //             param: new { AGENCYID = agencyId },
        //             transaction: _transaction
        //             ).ToList();
        // }
        public DocumentType FetchRequestedDocDetails(short agencyID, string documentName)
        {
            var documentNameLike = "%" + documentName + "%";
            var selectQuery = @"SELECT * FROM SHRD.dbo.DocumentType where AgencyID = @AGENCYID and Name Like @DOCUMENTNAME";
            return _connection.Query<DocumentType>(
                    selectQuery,
                   param: new
                   {
                       AGENCYID = agencyID,
                       DOCUMENTNAME = documentNameLike
                   },
                   transaction: _transaction
              ).FirstOrDefault();
        }

        #endregion
    }
}
