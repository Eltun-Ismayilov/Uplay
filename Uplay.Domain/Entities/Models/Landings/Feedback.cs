using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Domain.Entities.Models.Landing
{
    public class Feedback:CommonEntity
    {
        public string Name { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
