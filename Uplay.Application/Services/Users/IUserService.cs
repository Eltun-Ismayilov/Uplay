namespace Uplay.Application.Services.Users
{
    public interface IUserService:IBaseService
    {
        Task<string> SubscibeConfirm(string token);
    }
}
