namespace Uplay.Application.Models.Core.Feedbacks;

public class FeedbackFilter
{
    public int? FeedbackTypeId { get; set; }
    public int BranchId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}