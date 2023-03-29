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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        #region public constructors

        public CountryRepository(IDbConnection context) : base(context)
        {
            TableName = "[SHRD].[dbo].[Country]";
            PrimaryKeyName = "Code";
        }

        #endregion

        #region Public methods


        public List<Country> GetCountriesList(List<string> countries)
        {
            return _connection.Query<Country>(
                    @"SELECT * FROM shrd.dbo.Country WHERE NAME IN @COUNTRYLIST",
                    param: new { COUNTRYLIST = countries },
                    transaction: _transaction
                    ).ToList();
        }

        #endregion
    }
}