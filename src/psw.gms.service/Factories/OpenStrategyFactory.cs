// using PSW.GMS.Service.Strategies.Print;
using PSW.GMS.Data;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.Strategies;

namespace PSW.GMS.Service.Factories
{
    public class OpenStrategyFactory : IStrategyFactory
    {
        #region Private Variables

        #endregion

        #region Properties
        public IUnitOfWork UnitOfWork { get; protected set; }

        #endregion

        #region Constructor

        public OpenStrategyFactory(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        #endregion

        #region Private Method

        #endregion

        #region Public Methods

        public Strategy CreateStrategy(CommandRequest request)
        {

            switch (request.methodId)
            {
                // case "2010": return new DownloadCertificateStrategy(request);
                default: break;
            }

            return new InvalidStrategy(request);
        }

        #endregion

    }

}
