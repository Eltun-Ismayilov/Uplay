using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Domain.Entities.Models.Landing
{
    public class Feedback:CommonEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int FeedbackTypeId { get; set; }
        public FeedbackType FeedbackType { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
