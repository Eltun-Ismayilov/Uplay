namespace Uplay.Application.Models.Core.Reviews;

public class ReviewFilter
{
    public int BranchId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}