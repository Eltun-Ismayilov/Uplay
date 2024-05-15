using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Domain.Entities.Models.Companies
{
    public class BranchReview:CommonEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
