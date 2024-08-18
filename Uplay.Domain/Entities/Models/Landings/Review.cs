using Uplay.Application.Models;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Domain.Entities.Models.Landing
{
    public class Review:CommonEntity, IFilterable
    {
        public string Name { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
