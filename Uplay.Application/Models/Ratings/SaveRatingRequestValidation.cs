using FluentValidation;
using Uplay.Application.Models.PublicReviews;

namespace Uplay.Application.Models.Ratings
{
    public class SaveRatingRequestValidation : BaseValidator<SaveRatingRequest>
    {
        public SaveRatingRequestValidation()
        {
            RuleFor(x => x.BranchId).NotEmpty().GreaterThan(0).WithMessage("BranchId is required");
            RuleFor(x => x.Rating).NotEmpty().GreaterThan(0).WithMessage("Rating is required");
        }
    }
}
