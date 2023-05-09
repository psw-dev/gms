using FluentValidation;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.ModelValidators
{
    public class UpdateGuaranteeTransactionRequestDTOValidator : AbstractValidator<UpdateGuaranteeTransactionRequestDTO>
    {
        public UpdateGuaranteeTransactionRequestDTOValidator()
        {
            CascadeMode = CascadeMode.Stop; // Stops Validating at first Failure 

            RuleFor(x => x.RoleCode)
            .NotEmpty()
            .NotNull()
            .WithName("roleCode")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.GuaranteeID)
            .NotEmpty()
            .NotNull()
            .WithName("guaranteeID")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.TraderNTN)
            .NotEmpty()
            .NotNull()
            .WithName("traderNTN")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.AttachedToDocumentID)
            .NotEmpty()
            .NotNull()
            .WithName("attachedToDocumentID")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.AttachedToDocumentTypeCode)
            .NotEmpty()
            .NotNull()
            .WithName("attachedToDocumentTypeCode")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.GuaranteeTransactionStatusID)
            .NotEmpty()
            .NotNull()
            .WithName("guaranteeTransactionStatusID")
            .WithMessage("'{PropertyName}' should not be null.");
        }
    }
}
