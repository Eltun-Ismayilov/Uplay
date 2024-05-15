namespace Uplay.Domain.Entities.Models.Companies
{
    public class CompanyBranch:CommonEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
