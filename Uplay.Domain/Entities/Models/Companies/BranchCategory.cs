namespace Uplay.Domain.Entities.Models.Companies
{
    public class BranchCategory
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
