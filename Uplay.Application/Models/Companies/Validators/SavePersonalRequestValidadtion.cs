using FluentValidation;

namespace Uplay.Application.Models.Companies.Validators
{
    public class SavePersonalRequestValidadtion : BaseValidator<SavePersonalRequest>
    {
        public SavePersonalRequestValidadtion()
        {
            RuleFor(a => a.BrandName).NotNull().NotEmpty().WithMessage("BrandName is required");
            RuleFor(a => a.City).NotNull().NotEmpty().WithMessage("City is required");
            RuleFor(a => a.Location).NotNull().NotEmpty().WithMessage("Location is required");
            RuleFor(a => a.File).NotNull().NotEmpty().WithMessage("File is required");
            RuleFor(x => x.CategoryIds)
                        .NotNull().WithMessage("CategoryIds cannot be null")
                        .Must(x => x != null && x.Count <= 3)
                        .WithMessage("CategoryIds must contain at least 3 items.");
        }
    }
}
