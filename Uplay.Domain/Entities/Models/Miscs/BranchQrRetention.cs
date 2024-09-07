using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Domain.Entities.Models.Miscs;

public class BranchQrRetention: CommonEntity
{
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public long QrRetCount { get; set; } 
    public string Date  { get; set; } 
}