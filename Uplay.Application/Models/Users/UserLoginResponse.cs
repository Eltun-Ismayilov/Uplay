namespace Uplay.Application.Models.Users
{
    public class UserLoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserLoginResponse(string token) => Token = token;
    }
}
