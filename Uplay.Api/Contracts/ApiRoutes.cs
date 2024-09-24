namespace Uplay.Api.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public struct FileRoute
        {
            public const string GetAll = Base + "/file";
            public const string Create = Base + "/file";
        }

        public struct FaqRoute
        {
            public const string GetAll = Base + "/faq";
            public const string Get = Base + "/faq/:id";
            public const string Update = Base + "/faq/:id";
            public const string Create = Base + "/faq";
            public const string Delete = Base + "/faq/:id";
        }
        public struct RatingBranchRoute
        {
            public const string GetAll = Base + "/RatingBranch";
            public const string Get = Base + "/RatingBranch/:branchId";
            public const string GetStatistics = Base + "/RatingBranchStatistics";
        }


        
        public struct RatingRoute
        {
            public const string Create = Base + "/rating";
        }
        
        public struct CityRoute
        {
            public const string City = Base + "/CityRoute";
        }
        
        public struct PricingRoute
        {
            public const string GetAll = Base + "/pricing";
            public const string Get = Base + "/pricing/:id";
            public const string Update = Base + "/pricing/:id";
            public const string Create = Base + "/pricing";
            public const string Delete = Base + "/pricing/:id";
        }

        public struct SocialLinkRoute
        {
            public const string Get = Base + "/socialLink";
            public const string Update = Base + "/socialLink/:id";
            public const string Create = Base + "/socialLink";
        }


        public struct ServiceRoute
        {
            public const string GetAll = Base + "/service";
            public const string Get = Base + "/service/:id";
            public const string Update = Base + "/service/:id";
            public const string Create = Base + "/service";
            public const string Delete = Base + "/service/:id";
        }
        public struct PartnerRoute
        {
            public const string GetAll = Base + "/partner";
            public const string Get = Base + "/partner/:id";
            public const string Update = Base + "/partner/:id";
            public const string Create = Base + "/partner";
            public const string Delete = Base + "/partner/:id";
        }
        public struct AboutRoute
        {
            public const string Get = Base + "/about";
            public const string Update = Base + "/about/:id";
            public const string Create = Base + "/about";
        }

        public struct UserRoute
        {
            public const string Login = Base + "/login";
            public const string LoginB = Base + "/loginb";
            public const string ResetPassword = Base + "/resetPassword";
            public const string ForgetPassword = Base + "/forgetpassword";
            public const string ConfirmForgetPassword = Base + "/confirmforgotpassword";
            public const string SendOtp = Base + "/SendOtp";
            public const string DeleteBranchAccount = Base + "/branch/account";
            public const string DeleteCompanyAccount = Base + "/company/account";
            public const string GetBranchAccountInfo = Base + "/branch/account";
            public const string GetCompanyAccountInfo = Base + "/company/account";
            public const string UpdateBranchAccountInfo = Base + "/branch/account";
            public const string UpdateCompanyAccountInfo = Base + "/company/account";
            
        }
        public struct PublicReviewRoute
        {
            public const string GetAll = Base + "/publicReview";
            public const string Get = Base + "/publicReview/:id";
            public const string Update = Base + "/publicReview/:id";
            public const string Create = Base + "/publicReview";
            public const string Delete = Base + "/publicReview/:id";
        }

        public struct ContactRoute
        {
            public const string GetAll = Base + "/contact";
            public const string Get = Base + "/contact/:id";
            public const string Create = Base + "/contact";
        }
        public struct CompanyRoute
        {
            public const string CreateCorporate = Base + "/corporate";
            public const string CreatePersonal = Base + "/personal";
            public const string Get = Base + "/company/:id";
        }

        public struct ReviewRoute
        {
            public const string GetAll = Base + "/review/:id";
            public const string Create = Base + "/review";
        }

        public struct FeedbackRoute
        {
            public const string GetAll = Base + "/feedback/:id";
            public const string Create = Base + "/feedback";
            public const string GetStatistics = Base + "/branch/statistics";
        }
        
        public struct BranchRoute
        {
            public const string CreateBranch= Base + "/branch";
            public const string GetAllBranch = Base + "/branch";
            public const string GetBranch = Base + "/branch/:id";
            public const string DeleteBranch= Base + "/branch/delete/:id";
            public const string DisableBranch = Base + "/branch/disable/:id";
            public const string GetBranchIdByQrcode = Base + "/branch/qrCode/:id";
        }
        
        public struct FeedbackTypeRoute
        {
            public const string GetAll = Base + "/feedbackType";
            public const string Create = Base + "/feedbackType";
            public const string Update = Base + "/feedbackType/:id";
            public const string Delete = Base + "/feedbackType/:id";
        }
        
        public struct PlaylistRoute
        {
            public const string GetAll = Base + "/playlist";
            public const string Create = Base + "/playlist";
            public const string Update = Base + "/playlist/:id";
            public const string Topthree = Base + "/topThreePlaylist/:branchId";
        }
    }
}
