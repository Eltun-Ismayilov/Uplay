using FluentValidation;

namespace Uplay.Application.Models.Companies.Validators
{
    public class SaveCompanyRequestValidator : BaseValidator<SaveCompanyRequest>
    {
        public SaveCompanyRequestValidator()
        {
            RuleFor(a => a.BrandName).NotNull().NotEmpty().WithMessage("BrandName is required");
            RuleFor(a => a.CompanyName).NotNull().NotEmpty().WithMessage("CompanyName is required");
            RuleFor(a => a.Tin).NotNull().NotEmpty().WithMessage("Tin is required");
            RuleFor(a => a.BranchCount).NotNull().NotEmpty().WithMessage("BranchCount is required");
            RuleFor(a => a.City).NotNull().NotEmpty().WithMessage("City is required");
            RuleFor(a => a.Location).NotNull().NotEmpty().WithMessage("Location is required");
            RuleFor(a => a.File).NotNull().NotEmpty().WithMessage("File is required");
        }
    }
}
