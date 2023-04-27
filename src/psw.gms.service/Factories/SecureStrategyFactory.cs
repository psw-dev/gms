using PSW.GMS.Service.Command;
using PSW.GMS.Data;
using PSW.GMS.Service.Strategies.Calculator;

namespace PSW.GMS.Service.Strategies
{
    public class SecureStrategyFactory : IStrategyFactory
    {
        #region Properties

        public IUnitOfWork UnitOfWork { get; protected set; }

        #endregion

        #region Constructor

        public SecureStrategyFactory(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        #endregion

        #region Public Methods

        public Strategy CreateStrategy(CommandRequest request)
        {
            switch (request.methodId)
            {
                case "1": return new IntCalculatorAddStrategy(request);
                case "2": return new IntCalculatorSubtractStrategy(request);
                case "3": return new IntCalculatorMultiplyStrategy(request);
                case "4": return new IntCalculatorDivideStrategy(request);
                case "5": return new DoubleCalculatorAddStrategy(request);
                case "6": return new DoubleCalculatorSubtractStrategy(request);
                case "7": return new DoubleCalculatorMultiplyStrategy(request);
                case "8": return new DoubleCalculatorDivideStrategy(request);
                case "2301": return new SaveGuaranteeDocumentStrategy(request);
                
                default: return new InvalidStrategy(request);
            }
        }

        #endregion

    }
}
