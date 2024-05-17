using FluentValidation;

namespace Uplay.Application.Models.PublicReviews
{
    public class SavePublicReviewRequestValidator : BaseValidator<SavePublicReviewRequest>
    {
        public SavePublicReviewRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.File).NotEmpty().WithMessage("File is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
