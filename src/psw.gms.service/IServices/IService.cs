using PSW.Common.Crypto;
using PSW.GMS.Service.Command;
using PSW.GMS.Data;
using PSW.GMS.Service.Strategies;

namespace PSW.GMS.Service
{
    public interface IService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IStrategyFactory StrategyFactory { get; set; }
        CommandReply invokeMethod(CommandRequest request);
        ICryptoAlgorithm CryptoAlgorithm { get; set; }
        CommandReply Invoke(CommandRequest request);
        int LoggedInUserRoleId { get; set; }
    }
}