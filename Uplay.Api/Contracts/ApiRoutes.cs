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
    }
}
