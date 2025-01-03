using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enums.User;
using Uplay.Domain.Extension;

namespace Uplay.Domain.Seeders
{
    public static class EntitySeeders
    {
        public static List<Role> SeedRoles()
         => Enum.GetValues<RoleEnum>().ToList().Select(e => new Role()
         {
             Id = (int)e,
             Name = e.GetDescription(),
             CreatedDate = DateTime.UtcNow,
             Deleted = false,
         }).ToList();

        public static List<Claim> SeedClaims()
         => Enum.GetValues<ClaimEnum>().ToList().Select(e => new Claim()
         {
             Id = (int)e,
             Name = e.GetDescription(),
             CreatedDate = DateTime.UtcNow,
             Deleted = false,
         }).ToList();

        public static List<RoleClaim> SeedRoleClaims()
        {
            return new()
            {
                new RoleClaim() {Id=1,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.About_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=2,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.About_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=3,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Branch_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=4,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Branch_Disable.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=5,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Category_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=6,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Branch_Statistics_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=7,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Branch_Qr_Retention_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=8,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Contact_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=9,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Contact_Details.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=10,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Faq_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=11,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Faq_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=12,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Faq_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=13,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.FeedbackType_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=14,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.FeedbackType_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=15,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.FeedbackType_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=16,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Partner_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=17,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Partner_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=18,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Partner_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=19,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Playlist_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=20,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.PublicReview_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=21,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.PublicReview_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=22,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.PublicReview_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=23,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Service_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=24,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Service_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=25,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Service_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=26,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.SocialLink_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=27,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.SocialLink_Put.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=28,RoleId=RoleEnum.SuperAdmin.ToInt(),ClaimId=ClaimEnum.Company_Delete.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},

                //Admin

                new RoleClaim() {Id=29,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.About_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=30,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.PublicReview_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=31,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Category_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=32,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Branch_Statistics_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=33,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Service_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=34,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Branch_Qr_Retention_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=35,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Contact_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=36,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.SocialLink_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=37,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Contact_Details.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=38,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Faq_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=39,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.FeedbackType_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=40,RoleId=RoleEnum.Admin.ToInt(),ClaimId=ClaimEnum.Partner_Post.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},

                //Operator

                new RoleClaim() {Id=41,RoleId=RoleEnum.Operator.ToInt(),ClaimId=ClaimEnum.Branch_Statistics_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=42,RoleId=RoleEnum.Operator.ToInt(),ClaimId=ClaimEnum.Branch_Qr_Retention_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=43,RoleId=RoleEnum.Operator.ToInt(),ClaimId=ClaimEnum.Contact_Get.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
                new RoleClaim() {Id=44,RoleId=RoleEnum.Operator.ToInt(),ClaimId=ClaimEnum.Contact_Details.ToInt(),CreatedDate=DateTime.UtcNow,Deleted=false},
            };
        }
    }
}
