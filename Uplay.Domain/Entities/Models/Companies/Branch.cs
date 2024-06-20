using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enum;

namespace Uplay.Domain.Entities.Models.Companies
{
    public class Branch:CommonEntity
    {
        public string Name { get; set; }
        public string Tin { get; set; }
        public virtual ICollection<BranchCategory> BranchCategories { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        // public int CreationWallet { get; set; }
        // public int UpdateWallet { get; set; }
        public int OnwerId { get; set; }
        public User Onwer { get; set; }
        public AccauntStatusEnum Status { get; set; }
        public virtual ICollection<PlayList> PlayLists { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BranchQrCode> BranchQrCodes { get; set; }
    }
}
