using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Domain.Entities.Models.Companies
{
    public class BranchFeedback:CommonEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; }
    }
}
