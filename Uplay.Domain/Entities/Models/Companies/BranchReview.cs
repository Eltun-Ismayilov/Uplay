namespace Uplay.Domain.Entities.Models.Companies
{
    public class BranchReview
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
