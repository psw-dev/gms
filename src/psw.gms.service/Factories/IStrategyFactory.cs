
using PSW.GMS.Service.Command;

namespace PSW.GMS.Service.Strategies
{
    public interface IStrategyFactory
    {
        Strategy CreateStrategy(CommandRequest request);
    }
}