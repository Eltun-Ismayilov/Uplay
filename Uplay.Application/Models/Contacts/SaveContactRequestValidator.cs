using FluentValidation;

namespace Uplay.Application.Models.Contacts;

public class SaveContactRequestValidator: BaseValidator<SaveContactRequest>
{
    public SaveContactRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
        RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required");
    }
}