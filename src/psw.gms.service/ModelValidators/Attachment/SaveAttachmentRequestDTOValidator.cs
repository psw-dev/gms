using FluentValidation;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.ModelValidators
{
    public class SaveAttachmentRequestDTOValidator : AbstractValidator<SaveAttachmentRequestDTO>
    {
        public SaveAttachmentRequestDTOValidator()
        {
            CascadeMode = CascadeMode.Stop; // Stops Validating at first Failure 

            RuleForEach(a => a.Attachments).ChildRules(attachment =>
            {
                attachment.RuleFor(x => x.OwnerDocumentTypeCode)
                .NotEmpty()
                .NotNull()
                .WithName("ownerDocumentTypeCode")
                .WithMessage("'{PropertyName}' should not be null.");

                attachment.RuleFor(x => x.OwnerDocumentID)
                .NotEmpty()
                .NotNull()
                .WithName("ownerDocumentID")
                .WithMessage("'{PropertyName}' should not be null.");

                attachment.RuleFor(x => x.AttachedObjectFormatID)
                .NotEmpty()
                .NotNull()
                .WithName("attachedObjectFormatID")
                .WithMessage("'{PropertyName}' should not be null.");

                attachment.RuleFor(x => x.AttachedDocumentTypeCode)
                .NotEmpty()
                .NotNull()
                .WithName("attachedDocumentTypeCode")
                .WithMessage("'{PropertyName}' should not be null.");

                attachment.RuleFor(x => x.AttachedDocumentID)
                .NotEmpty()
                .NotNull()
                .WithName("attachedDocumentID")
                .WithMessage("'{PropertyName}' should not be null.");
            });
        }
    }
}
