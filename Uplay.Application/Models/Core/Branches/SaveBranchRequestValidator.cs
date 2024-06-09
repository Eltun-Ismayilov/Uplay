using FluentValidation;

namespace Uplay.Application.Models.Core.Branches;

public class SaveBranchRequestValidator: BaseValidator<SaveBranchRequest>
{
    public SaveBranchRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
        RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(a => a.CategoryIds).NotNull().NotEmpty().WithMessage("CategoryIds is required");
    }
}