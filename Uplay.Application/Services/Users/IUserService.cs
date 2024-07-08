using Uplay.Application.Models.Users;

namespace Uplay.Application.Services.Users
{
    public interface IUserService : IBaseService
    {
        Task<string> SubscibeConfirm(int otp);
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<UserLoginResponse> BranchLogin(UserLoginRequest request);
        public string Username { get; set; }
        Task<string> ResetPassword(ResetPasswordRequest request);
        Task<string> SendForgotPasswordEmail(string email);
        Task<string> ConfirmResetPassword( ConfirmResetPasswordRequest request);
    }
}