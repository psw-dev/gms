using FluentValidation;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.ModelValidators
{
    public class IntCalculatorDTOValidator : AbstractValidator<IntCalculatorRequestDTO>
    {
        public IntCalculatorDTOValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.a)
                .NotEmpty().WithMessage("first number not found");
            RuleFor(c => c.b)
                .NotEmpty().WithMessage("second number not found");
        }
    }
}