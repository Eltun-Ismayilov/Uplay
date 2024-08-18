namespace Uplay.Application.Models;

public class FilterQuery
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int BranchId { get; set; }
}