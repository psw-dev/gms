using PSW.GMS.Service.Command;

namespace PSW.GMS.Service.Strategies
{
    public class TestSecureGmsStrategy : ApiStrategy<string, string>
    {
        public TestSecureGmsStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
        }
    }
}