namespace Uplay.Application.Models;

public interface IFilterable
{
    public DateTime CreatedDate { get; set; }
    public int BranchId { get; set; }
}