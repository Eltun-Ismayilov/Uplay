using FluentValidation;

namespace Uplay.Application.Models.Companies.Validators
{
    public class SaveUserRequestValidator : BaseValidator<SaveUserRequest>
    {
        public SaveUserRequestValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(a => a.Surname).NotNull().NotEmpty().WithMessage("Surname is required");
            RuleFor(a => a.Phone).NotNull().NotEmpty().WithMessage("Phone is required");
            RuleFor(a => a.UserName).NotNull().NotEmpty().WithMessage("UserName is required");
            RuleFor(a => a.Email).NotNull().NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not format");
            RuleFor(a => a.Password).NotNull().NotEmpty().WithMessage("Password is required");
            RuleFor(a => a.ConfirmPassword).NotNull().NotEmpty().WithMessage("ConfirmPassword is required");
        }
    }
}
