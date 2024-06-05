using Uplay.Application.Models.Users;

namespace Uplay.Application.Services.Users
{
    public interface IUserService:IBaseService
    {
        Task<string> SubscibeConfirm(string token);
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
