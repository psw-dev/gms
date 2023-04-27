/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

using PSW.GMS.Common;
using PSW.GMS.Data.Repositories;
using PSW.GMS.Data.Sql.Repositories;
// using PSW.Repositories;
// using PSW.Sql.Repositories;
using PSW.RabbitMq;


namespace PSW.GMS.Data.Sql
{

    public class UnitOfWork : IUnitOfWork
    {
        #region Private Properties GMS
        private IGuaranteeRepository _guaranteeRepository;
        private IGuaranteeTransactionHistoryRepository _guaranteeTransactionHistoryRepository;
        #endregion

        #region Private Properties SHRD

        #endregion

        #region Private Properties SHRD Views

        #endregion

        #region Public Properties GMS
        public IGuaranteeRepository GuaranteeRepository => _guaranteeRepository ?? (_guaranteeRepository = new GuaranteeRepository(_connection));
        public IGuaranteeTransactionHistoryRepository GuaranteeTransactionHistoryRepository => _guaranteeTransactionHistoryRepository ?? (_guaranteeTransactionHistoryRepository = new GuaranteeTransactionHistoryRepository(_connection));
        #endregion

        #region Public Properties SHRD
        
        #endregion

        //EventBusXml to Send request to IRMS
        private IEventBus _eventBus;

        public IEventBus eventBus => _eventBus;
        //private IEventBus _eventBus;

        //public IEventBus eventBus => _eventBus;
        private IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration, IEventBus evBus)
        {
            _eventBus = evBus;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));

        }
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
        }
        public UnitOfWork()
        {
            // TODO : Get Connection String From appSetting.json
            string connectionString = "Server=127.0.0.1;Initial Catalog=GMS;User ID=sa;Password=@Password1;";
            _connection = new SqlConnection(connectionString);
            // _connection.Open();
        }

        public UnitOfWork(string connectionString)
        {

            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null) _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));

                return _connection;
            }

            set
            {
                _connection = value;
            }
        }

        #region Private variables 
        private IDbConnection _connection; // = new SqlConnection(_configuration.GetConnectionString("SQLConnectionString")); ;	
        private IDbTransaction _transaction;
        #endregion


        #region Public methods

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public List<object> ExecuteQuery(string query)
        {
            return (List<object>)_connection.Query<List<object>>(query);
        }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CloseConnection()
        {
            try
            {
                //if (_transaction != null)
                //    _transaction.Commit();
                if (_connection != null && _connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BeginTransaction()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                _transaction = _connection.BeginTransaction();

                SetTransactions(_transaction);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SetTransactions(IDbTransaction transaction)
        {
            var repositories = this.GetType().GetProperties();

            foreach (PropertyInfo r in repositories)
            {
                if (Utility.IsAssignableToGenericType(r.PropertyType, typeof(Data.Repositories.IRepository<>)))
                {

                    var repo = r.GetValue(this) as IRepositoryTransaction;
                    repo.SetTransaction(transaction);

                }
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Commit();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Rollback();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
