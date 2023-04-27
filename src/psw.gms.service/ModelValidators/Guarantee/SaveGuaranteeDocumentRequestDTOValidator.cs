using FluentValidation;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.ModelValidators
{
    public class SaveGuaranteeDocumentRequestDTOValidator : AbstractValidator<SaveGuaranteeDocumentRequestDTO>
    {
        public SaveGuaranteeDocumentRequestDTOValidator()
        {
            CascadeMode = CascadeMode.Stop; // Stops Validating at first Failure 

            RuleFor(x => x.RoleCode)
            .NotEmpty()
            .NotNull()
            .WithName("roleCode")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.GuaranteeTypeID)
            .NotEmpty()
            .NotNull()
            .WithName("guaranteeTypeID")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.TraderNTN)
            .NotEmpty()
            .NotNull()
            .WithName("traderNTN")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.AgentNTN)
            .NotEmpty()
            .NotNull()
            .WithName("agentNTN")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.GuaranteeNumber)
            .NotEmpty()
            .NotNull()
            .WithName("guaranteeNumber")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.TotalAmount)
            .NotEmpty()
            .NotNull()
            .WithName("totalAmount")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .NotNull()
            .WithName("currencyCode")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.IssueDate)
            .NotEmpty()
            .NotNull()
            .WithName("issueDate")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.ExpiryDate)
            .NotEmpty()
            .NotNull()
            .WithName("expiryDate")
            .WithMessage("'{PropertyName}' should not be null.");

            RuleFor(x => x.BankCode)
            .NotEmpty()
            .NotNull()
            .WithName("bankCode")
            .WithMessage("'{PropertyName}' should not be null.");

        }
    }
}
