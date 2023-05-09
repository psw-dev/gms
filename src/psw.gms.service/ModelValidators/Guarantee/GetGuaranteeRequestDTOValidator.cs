using FluentValidation;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.ModelValidators
{
    public class GetGuaranteeRequestDTOValidator : AbstractValidator<GetGuaranteeRequestDTO>
    {
        public GetGuaranteeRequestDTOValidator()
        {
            CascadeMode = CascadeMode.Stop; // Stops Validating at first Failure 

            RuleFor(x => x.RoleCode)
            .NotEmpty()
            .NotNull()
            .WithName("roleCode")
            .WithMessage("'{PropertyName}' should not be null.");

        }
    }
}
