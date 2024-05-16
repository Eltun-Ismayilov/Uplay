using FluentValidation;

namespace Uplay.Application.Models.Faqs;

public class SaveFaqRequestValidator : BaseValidator<SaveFaqRequest>
{
    public SaveFaqRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
    }
}