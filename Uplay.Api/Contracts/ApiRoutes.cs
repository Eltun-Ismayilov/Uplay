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
        
        public struct PartnerRoute
        {
            public const string GetAll = Base + "/partner";
            public const string Get = Base + "/partner/:id";
            public const string Update = Base + "/partner/:id";
            public const string Create = Base + "/partner";
            public const string Delete = Base + "/partner/:id";
        }
        
        public struct ContactRoute
        {
            public const string GetAll = Base + "/contact";
            public const string Get = Base + "/contact/:id";
            public const string Create = Base + "/contact";
        }
    }
}
