using FluentValidation;

namespace Uplay.Application.Models.Core.Reviews;

public class SaveReviewRequestValidator: BaseValidator<SaveReviewRequest>
{
    public SaveReviewRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.BranchId).NotEmpty().WithMessage("Branch is required");
    }
}