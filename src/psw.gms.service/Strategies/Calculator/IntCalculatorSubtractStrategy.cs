using System.Text.Json;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.GMS.Service.ModelValidators;
using Calc = PSW.GMS.Service.Calculator.Calculator;

namespace PSW.GMS.Service.Strategies.Calculator
{
    public class IntCalculatorSubtractStrategy : ApiStrategy<IntCalculatorRequestDTO, int>
    {
        public IntCalculatorSubtractStrategy(CommandRequest request) : base(request)
        {
            this.Reply = new CommandReply();
            this.Validator = new IntCalculatorDTOValidator();
        }

        public override CommandReply Execute()
        {
            Calc calc = new Calc();

            ResponseDTO = calc.subtract(RequestDTO.a, RequestDTO.b);
            return OKReply();
        }
    }
}