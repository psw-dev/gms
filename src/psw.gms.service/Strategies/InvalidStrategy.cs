using System.Text.Json;
using PSW.GMS.Service.Command;

namespace PSW.GMS.Service.Strategies
{
    public class InvalidStrategy : Strategy
    {
        public InvalidStrategy(CommandRequest request) : base(request)
        {

        }

        public override CommandReply Execute()
        {
            //this.Command
            string json = "{}";

            return new CommandReply()
            {
                message = "Invalid Method ID",
                data = JsonDocument.Parse(json).RootElement,
                code = "400"
            };
        }
        public override bool Validate()
        {
            return true;
        }
    }
}
