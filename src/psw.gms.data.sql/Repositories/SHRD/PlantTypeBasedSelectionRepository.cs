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
    public class PlantTypeBasedSelectionRepository : Repository<PlantTypeBasedSelection>, IPlantTypeBasedSelectionRepository
    {
        #region public constructors

        public PlantTypeBasedSelectionRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[PlantTypeBasedSelection]";
            PrimaryKeyName = "ID";
        }

        #endregion

        #region Public methods
        public List<PlantTypeBasedSelection> GetActivePlantBasedSelection()
        {
            var query = new Query("SHRD.dbo.PlantTypeBasedSelection as pbs")
                        .Where("pbs.IsActive", true)
                        .Where("pbs.EffectiveThruDate", ">", DateTime.Now)
                        .Select("pbs.*");
            var result = _sqlCompiler.Compile(query);
            var sql = result.Sql;
            var parameters = new DynamicParameters(result.NamedBindings);
            return _connection.Query<PlantTypeBasedSelection>(sql, parameters, _transaction).ToList();
        }

        #endregion
    }
}
