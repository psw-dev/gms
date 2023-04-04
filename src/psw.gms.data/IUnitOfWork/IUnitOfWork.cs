/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using PSW.GMS.Data.Repositories;
using PSW.RabbitMq;
// using PSW.Repositories;

namespace PSW.GMS.Data
{
    public interface IUnitOfWork : IDisposable
    {

        #region Rabbit MQ
        IEventBus eventBus { get; }

        #endregion

        #region SHRD Repositories
        #endregion

        #region SHRD View Repositories
        #endregion

        #region Methods
        void BeginTransaction();
        void Commit();
        void Rollback();

        void OpenConnection();
        void CloseConnection();

        #endregion
    }
}
