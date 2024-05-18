using FluentValidation;

namespace Uplay.Application.Models.Abouts.Validators
{
    public class SaveAboutTypeRequestValidator : BaseValidator<SaveAboutTypeRequest>
    {
        public SaveAboutTypeRequestValidator()
        {
            RuleFor(a => a.File).NotNull().NotEmpty().WithMessage("File is required");
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(a => a.Description).NotNull().NotEmpty().WithMessage("Description is required");
        }
    }
}
