/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;
using SqlKata;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class DocumentTypeBasedPlantTypeRepository : Repository<DocumentTypeBasedPlantType>, IDocumentTypeBasedPlantTypeRepository
    {
        #region public constructors

        public DocumentTypeBasedPlantTypeRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[DocumentTypeBasedPlantType]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods
        public List<DocumentBasedPlantTypeDTO> GetDocumentBasedPlantTypes(string documentTypeCode)
        {
            var query = new Query("SHRD.dbo.DocumentTypeBasedPlantType as dtpt")
                        .Join("SHRD.dbo.PlantType as pt", "dtpt.PlantTypeID", "pt.ID")
                        .Where("dtpt.DocumentTypeCode", documentTypeCode)
                        .Where("dtpt.IsActive", true)
                        .Where("dtpt.EffectiveThruDate", ">", DateTime.Now)
                        .Select("dtpt.{ID}", "pt.{ID as PlantTypeID,Name}");

            var result = _sqlCompiler.Compile(query);
            var sql = result.Sql;
            var parameters = new DynamicParameters(result.NamedBindings);
            return _connection.Query<DocumentBasedPlantTypeDTO>(sql, parameters, _transaction).ToList();
        }
        #endregion
    }
}
