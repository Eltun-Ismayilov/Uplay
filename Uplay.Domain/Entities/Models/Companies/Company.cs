using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Domain.Entities.Models.Company
{
    public class Company : CommonEntity
    {
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Tin { get; set; } //Voen
        public int BranchCount { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public virtual ICollection<CompanyCategory> CompanyCategories { get; set;}
        public int OnwerId { get; set; }
        public User Onwer{ get; set; }
    }
}
