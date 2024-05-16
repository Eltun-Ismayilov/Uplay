using FluentValidation;

namespace Uplay.Application.Models.Partners;

public class SavePartnerRequestValidator: BaseValidator<SavePartnerRequest>
{
    public SavePartnerRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.File).NotEmpty().WithMessage("File is required");
    }
}