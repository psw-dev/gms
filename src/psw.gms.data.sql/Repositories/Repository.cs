/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Repositories;
using PSW.GMS.Common.Pagination;
using SqlKata.Compilers;
using PSW.Lib.Logs;
using SqlKata;

namespace PSW.GMS.Data.Sql.Repositories
{
    /// <summary>
    /// the base class for all Repositories . this contains generic functionalities of all repositories
    /// like Get,Add etc..
    /// </summary>
    /// <typeparam name="T">the type of the Entity</typeparam>
	public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        #region Protected Fields

        protected IDbConnection _connection;
        protected IDbTransaction _transaction;
        protected SqlServerCompiler _sqlCompiler;

        #endregion

        #region Protected properties

        protected string TableName { get; set; }
        protected string PrimaryKeyName { get; set; }

        #endregion

        #region Public properties

        public Entity Entity { get; set; }

        #endregion

        #region Protected Constructors

        protected Repository(IDbConnection connection)
        {
            _connection = connection;
            _sqlCompiler = new SqlServerCompiler();
        }

        #endregion

        #region Public Methods

        public virtual T Get(int id)
        {
            return _connection.Query<T>(string.Format("SELECT TOP 1 * FROM {0} WHERE [{2}] = '{1}'", TableName, id, PrimaryKeyName),
                                        transaction: _transaction).FirstOrDefault();
        }

        public virtual T Get(string id)
        {
            return _connection.Query<T>(string.Format("SELECT TOP 1 * FROM {0} WHERE [{2}] = '{1}'", TableName, id, PrimaryKeyName),
                                        transaction: _transaction).FirstOrDefault();
        }

        public virtual IEnumerable<T> Get()
        {
            return (IEnumerable<T>)_connection.Query<T>(string.Format("SELECT * FROM {0}", TableName),
                                                        transaction: _transaction);
        }
        //TODO Implement Paramtrization
        /// <summary>
        /// Add with Primary Key Value
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public virtual int AddWithPK(T _entity)
        {
            var Entity = _entity;
            var query = "INSERT INTO {0} ({1}) VALUES({2}); SELECT SCOPE_IDENTITY()";

            var cols = new StringBuilder();
            var values = new StringBuilder();


            var columns = Entity.GetColumns();
            foreach (var item in columns)
            {
                cols.Append("[" + item.Key + "],");
                if (item.Value == null)
                    values.Append("NULL,");
                else
                    values.AppendFormat("'{0}',", item.Value.ToString().Replace("'", "''"));
            }

            query = string.Format(query, Entity.TableName, cols.ToString().TrimEnd(','), values.ToString().TrimEnd(',')) + ";";
            var sqlQuery = "Declare @id table (ID Bigint); " + query + " SELECT ID FROM @id;";
            sqlQuery = sqlQuery.Replace("VALUES", "OUTPUT inserted.ImportPermitItemID Into @id VALUES");

            Log.Information($"Repository | Add | Query: {query}");
            int result = _connection.ExecuteScalar<int>(query,
                                                        transaction: _transaction);
            return result;
        }


        public virtual int Add(T _entity)
        {
            var Entity = _entity;
            var query = "INSERT INTO {0} ({1}) VALUES({2}); SELECT SCOPE_IDENTITY()";

            var cols = new StringBuilder();
            var values = new StringBuilder();


            var columns = Entity.GetColumns();
            foreach (var item in columns.Where(c => c.Key != Entity.PrimaryKeyName))
            {
                cols.Append("[" + item.Key + "],");
                if (item.Value == null)
                    values.Append("NULL,");
                else
                    values.AppendFormat("'{0}',", item.Value.ToString().Replace("'", "''"));
            }

            query = string.Format(query, Entity.TableName, cols.ToString().TrimEnd(','), values.ToString().TrimEnd(',')) + ";";
            var sqlQuery = "Declare @id table (ID Bigint); " + query + " SELECT ID FROM @id;";
            sqlQuery = sqlQuery.Replace("VALUES", "OUTPUT inserted.ID Into @id VALUES");

            Log.Information($"Repository | Add | Query: {sqlQuery}");
            int result = _connection.ExecuteScalar<int>(sqlQuery,
                                                        transaction: _transaction);
            return result;
        }

        public virtual int AddItem(T _entity)
        {
            var Entity = _entity;
            var query = "INSERT INTO {0} ({1}) VALUES({2}); SELECT SCOPE_IDENTITY()";

            var cols = new StringBuilder();
            var values = new StringBuilder();


            var columns = Entity.GetColumns();
            foreach (var item in columns.Where(c => c.Key != Entity.PrimaryKeyName))
            {
                cols.Append("[" + item.Key + "],");
                if (item.Value == null)
                    values.Append("NULL,");
                else
                    values.AppendFormat("'{0}',", item.Value.ToString().Replace("'", "''"));
            }

            query = string.Format(query, this.TableName, cols.ToString().TrimEnd(','), values.ToString().TrimEnd(',')) + ";";
            var sqlQuery = "Declare @id table (ID Bigint); " + query + " SELECT ID FROM @id;";
            sqlQuery = sqlQuery.Replace("VALUES", "OUTPUT inserted.ID Into @id VALUES");

            Log.Information($"Repository | Add | Query: {sqlQuery}");
            int result = _connection.ExecuteScalar<int>(sqlQuery,
                                                        transaction: _transaction);
            return result;
        }
        public long AddAndReturnIdParam(T _entity)
        {
            var Entity = _entity;
            var query = "Declare @id table (ID Bigint);INSERT INTO {0} ({1}) OUTPUT inserted.ID Into @id VALUES({2}); SELECT ID FROM @id";
            var cols = new StringBuilder();
            var values = new StringBuilder();
            var columns = Entity.GetColumns();

            foreach (var item in columns.Where(c => c.Key != Entity.PrimaryKeyName))
            {
                cols.Append("[" + item.Key + "],");

                if (item.Value == null)
                {
                    values.Append("NULL,");
                }
                else
                {
                    values.AppendFormat("'{0}',", item.Value.ToString().Replace("'", "''"));
                }
            }

            query = string.Format(query, Entity.TableName, cols.ToString().TrimEnd(','), values.ToString().TrimEnd(',')) + ";";

            Log.Information($"Repository | AddAndReturnIdParam | Query: {query}");
            var result = _connection.ExecuteScalar<long>(query, transaction: _transaction);
            return result;
        }
        public virtual void Delete(Entity _entity)
        {
            var Entity = _entity;
            var query = string.Format("DELETE {0} WHERE {2} = '{1}';", Entity.TableName, Entity.PrimaryKey, Entity.PrimaryKeyName);

            Log.Information($"Repository | Delete | Query: {query}");
            _connection.Execute(query,
                                transaction: _transaction);
        }

        public int Add(T _entity, bool getIntPrimaryKey)
        {
            var Entity = _entity;
            var query = "INSERT INTO {0} ({1}) VALUES({2});";

            var cols = new StringBuilder();
            var values = new StringBuilder();


            var columns = Entity.GetColumns();
            foreach (var item in columns.Where(c => c.Key != Entity.PrimaryKeyName))
            {
                cols.Append("[" + item.Key + "],");
                if (item.Value == null)
                    values.Append("NULL,");
                else
                    values.AppendFormat("'{0}',", item.Value.ToString().Replace("'", "''"));
            }

            query = string.Format(query, Entity.TableName, cols.ToString().TrimEnd(','), values.ToString().TrimEnd(',')) + ";";

            var sqlQuery = "Declare @id table (ID Bigint); " + query + " SELECT ID FROM @id;";
            sqlQuery = sqlQuery.Replace("VALUES", "OUTPUT inserted.ID Into @id VALUES");

            Log.Information($"Repository | Add | Query: {sqlQuery}");

            int result = _connection.ExecuteScalar<int>(sqlQuery, transaction: _transaction);
            return result;
        }

        public virtual void Delete(int id)
        {
            _connection.Query<T>(string.Format("DELETE FROM {0} WHERE {2} = '{1}'", TableName, id, PrimaryKeyName),
                                 transaction: _transaction).FirstOrDefault();
        }

        public virtual List<T> Where(object propertyValues)
        {
            const string query = "SELECT * FROM {0} WHERE {1}";

            var whereBulder = new StringBuilder();
            var objectType = propertyValues.GetType();
            var first = true;
            foreach (var property in objectType.GetProperties())
            {
                whereBulder.AppendFormat("{2} {0} = '{1}'", property.Name, property.GetValue(propertyValues).ToString().Replace("'", "''"), first ? "" : "AND");
                first = false;
            }
            var sqlQuery = string.Format(query, TableName, whereBulder);
            Log.Information($"Repository | Where | Query: {sqlQuery}");

            return _connection.Query<T>(sqlQuery,
                                        transaction: _transaction).ToList();
        }



        public virtual List<T> GetPage(int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(TableName) || pageSize < 1 || pageNumber < 1 || string.IsNullOrWhiteSpace(PrimaryKeyName))
                return new List<T>();

            var query = @"SELECT * FROM {2} ORDER BY {3} OFFSET(({1}-1)*{0}) ROWS FETCH NEXT {1} ROWS ONLY";
            query = string.Format(query, pageSize, pageNumber, TableName, PrimaryKeyName);

            Log.Information($"Repository | GetPage | Query: {query}");
            return _connection.Query<T>(query,
                                        transaction: _transaction).ToList();
        }

        // To Get Paginated Data From Single Table 
        public virtual List<T> GetPaginatedData(ServerPaginationModel Pagination)
        {
            if (string.IsNullOrWhiteSpace(TableName) || Pagination == null || Pagination.offset < 0 || Pagination.Size < 0 || string.IsNullOrWhiteSpace(PrimaryKeyName))
                return new List<T>();

            if (string.IsNullOrEmpty(Pagination.SortColumn))
                Pagination.SortColumn = PrimaryKeyName;

            if (string.IsNullOrEmpty(Pagination.SortOrder))
                Pagination.SortOrder = "DESC";

            var query = @"SELECT * FROM {0} ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY";
            query = string.Format(query, TableName, Pagination.SortColumn, Pagination.SortOrder, Pagination.offset, Pagination.Size);

            Log.Information($"Repository | GetPaginatedData | Query: {query}");
            return _connection.Query<T>(query,
                                        transaction: _transaction).ToList();
        }
        // Get Paginated Data With Search Criteria, Global Search has limitations
        public virtual List<T> SearchPaginatedData(ServerPaginationModel Pagination, object searchFilters, bool fetchTotalCount = true, bool globalSearch = false)
        {
            if (string.IsNullOrWhiteSpace(TableName) || Pagination == null || Pagination.offset < 0 || Pagination.Size < 0 || string.IsNullOrWhiteSpace(PrimaryKeyName))
                return new List<T>();

            if (string.IsNullOrEmpty(Pagination.SortColumn))
                Pagination.SortColumn = PrimaryKeyName;

            if (string.IsNullOrEmpty(Pagination.SortOrder))
                Pagination.SortOrder = "DESC";


            // Prepare SearchCriteria 
            var searchCriteria = new StringBuilder();
            var objectType = searchFilters.GetType();
            var first = true;
            foreach (var property in objectType.GetProperties())
            {
                if (!(property.GetValue(searchFilters) == null || string.IsNullOrWhiteSpace(property.GetValue(searchFilters).ToString())))
                {
                    if (!globalSearch)
                    {
                        searchCriteria.AppendFormat("{2} {0} = '{1}'", property.Name, property.GetValue(searchFilters).ToString().Replace("'", "''"), first ? "" : "AND");
                        first = false;
                    }
                    else
                    {
                        searchCriteria.AppendFormat("{2} {0} like '%{1}%'", property.Name, property.GetValue(searchFilters).ToString().Replace("'", "''"), first ? "" : "OR");
                        first = false;
                    }
                }
            }


            // Add Where Clause if needed 
            var query = @"SELECT * FROM {0} WHERE {1} ORDER BY {2} {3} OFFSET {4} ROWS FETCH NEXT {5} ROWS ONLY";
            if (searchCriteria.Length == 0)
            {
                query = @"SELECT * FROM {0} ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY";
                query = string.Format(query, TableName, Pagination.SortColumn, Pagination.SortOrder, Pagination.offset, Pagination.Size);
            }
            else
            {
                query = string.Format(query, TableName, searchCriteria, Pagination.SortColumn, Pagination.SortOrder, Pagination.offset, Pagination.Size);
            }

            if (fetchTotalCount)
            {
                string totalCountQuery = "";

                if (searchCriteria.Length == 0)
                {
                    totalCountQuery = @"SELECT * FROM {0}";
                    totalCountQuery = string.Format(totalCountQuery, TableName);
                }
                else
                {
                    totalCountQuery = @"SELECT * FROM {0} WHERE {1}";
                    totalCountQuery = string.Format(totalCountQuery, TableName, searchCriteria);

                }

                Pagination.TotalRecords = _connection.Query<T>(totalCountQuery,
                                        transaction: _transaction).ToList().Count().ToString();
            }

            Log.Information($"Repository | SearchPaginatedData | Query: {query}");
            return _connection.Query<T>(query,
                                        transaction: _transaction).ToList();
        }

        public virtual int Update(Entity entity)
        {

            StringBuilder values = new StringBuilder();
            Dictionary<string, object> columns = entity.GetColumns();

            foreach (KeyValuePair<string, object> item in columns)
            {
                if (entity.PrimaryKeyName == item.Key)
                    continue;

                values.Append(string.Format(item.Value == null ? "{0}={1}," : "{0}='{1}',", item.Key, item.Value == null ? "null" : item.Value.ToString().Replace("'", "''")));
            }

            // Need to Remove last comma
            string colValues = values.ToString().TrimEnd(',');

            string query = string.Format("Update {0} Set {1} WHERE {2} = {3}", this.TableName, colValues, this.PrimaryKeyName, columns[this.PrimaryKeyName]); ;
            Log.Information($"Repository | Update | Query: {query}");

            int numberOfRowsUpdated = _connection.ExecuteScalar<int>(query,
                                                                    null,
                                                                    transaction: _transaction);

            Log.Information($"Repository | Update | No of Row. Updated: {numberOfRowsUpdated}");
            return numberOfRowsUpdated;
        }

        public virtual T Find(int id)
        {
            return _connection.Query<T>(
                string.Format("SELECT top 1 * FROM {0} where {1} = {2}", this.TableName, this.PrimaryKeyName, id),
                param: new { TableName = this.TableName, PrimaryKeyName = this.PrimaryKeyName, Id = id },
                transaction: _transaction
                ).FirstOrDefault();
        }

        public virtual T Find(string id)
        {
            string query = string.Format("SELECT top 1 * FROM {0} where [{1}] = '{2}'", this.TableName, this.PrimaryKeyName, id);
            return _connection.Query<T>(
                query,
                param: new { TableName = this.TableName, PrimaryKeyName = this.PrimaryKeyName, Id = id },
                transaction: _transaction
                ).FirstOrDefault();
        }

        public virtual void SetTransaction(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public virtual int Count(string ColumnValue, string ColumnName)
        {
            string query = string.Format("SELECT count({0}) FROM {1} where {0} = '{2}'", ColumnName, this.TableName, ColumnValue);
            int numberOfRecords = _connection.ExecuteScalar<int>(query, transaction: _transaction);
            return numberOfRecords;
        }

        public List<T> WhereIn(string column, List<int> ids)
        {
            var query = new Query().FromRaw(TableName);
            query = query.WhereIn(column, ids);
            var result = _sqlCompiler.Compile(query);
            var sql = result.Sql;
            var parameters = new DynamicParameters(result.NamedBindings);

            return _connection.Query<T>(sql, param: parameters, transaction: _transaction).ToList();
        }

        public List<T> WhereIn(string column, List<string> ids)
        {
            var query = new Query().FromRaw(TableName);
            query = query.WhereIn(column, ids);
            var result = _sqlCompiler.Compile(query);
            var sql = result.Sql;
            var parameters = new DynamicParameters(result.NamedBindings);

            return _connection.Query<T>(sql, param: parameters, transaction: _transaction).ToList();
        }


        #endregion
    }
}