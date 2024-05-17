using FluentValidation;

namespace Uplay.Application.Models.Services
{
    public class SaveServiceRequestValidator : BaseValidator<SaveServiceRequest>
    {
        public SaveServiceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.File).NotEmpty().WithMessage("File is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.ServiceTypeId).NotEmpty().WithMessage("ServiceTypeId is required");
        }
    }
}
