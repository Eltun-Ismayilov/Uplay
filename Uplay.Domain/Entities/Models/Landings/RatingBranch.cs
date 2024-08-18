using Uplay.Application.Models;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Domain.Entities.Models.Landings
{
    public class RatingBranch:CommonEntity, IFilterable
    {
        public int Rating { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
