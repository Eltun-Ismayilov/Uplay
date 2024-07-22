using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Domain.Entities.Models.Landings
{
    public class FeedbackType:CommonEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
