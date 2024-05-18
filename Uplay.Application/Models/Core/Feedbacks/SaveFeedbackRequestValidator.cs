using FluentValidation;
using Uplay.Application.Models.Core.Feedbacks;

namespace Uplay.Application.Models.Feedbacks;

public class SaveFeedbackRequestValidator: BaseValidator<SaveFeedbackRequest>
{
    public SaveFeedbackRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.BranchId).NotEmpty().WithMessage("Branch is required");
    }
}