using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Domain.Entities.Models.Companies
{
    /// <summary>
    /// BranchCount -Company elave edende ne qeder brach elave de biler
    /// </summary>
    public class Company : CommonEntity
    {
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string? Tin { get; set; }
        public int BranchCount { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public int OnwerId { get; set; }
        public User Onwer { get; set; }
        public bool Aktiv { get; set; } = false;
        public virtual ICollection<CompanyBranch> CompanyBranchs { get; set; }
    }
}
