/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;

namespace PSW.GMS.Data.Sql.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDbConnection context) : base(context)
        {
            TableName = "[dbo].[City]";
            PrimaryKeyName = "ID";
        }

        public List<City> GetCitiesByIds(List<int> cityIds)
        {
            try
            {
                return _connection.Query<City>(
                 @"
                    SELECT [ID],
                           [Name]
                    FROM [SHRD].[dbo].[City]
                    WHERE ID IN @idList",
                    new { idList = cityIds },
                    _transaction).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<City> GetCollectorateCities()
        {
            return _connection.Query<City>(
                @"
                    SELECT [ID],
                           [CountryCode],
                           [Name],
                           [ParentCollectorateCode]
                    FROM [SHRD].[dbo].[City]
                    WHERE CountryCode = 'PK'
                          AND [ParentCollectorateCode] IS NOT NULL;

                ", _transaction).ToList();
        }
    }
}
