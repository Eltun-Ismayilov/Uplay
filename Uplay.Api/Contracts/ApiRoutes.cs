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
        public struct PricingRoute
        {
            public const string GetAll = Base + "/pricing/:id";
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
            public const string GetAll = Base + "/contact";
            public const string Get = Base + "/contact/:id";
            public const string Create = Base + "/company";
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
        }
    }
}
