using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Domain.Entities.Models.Landings
{
    public class FeedbackType:CommonEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
