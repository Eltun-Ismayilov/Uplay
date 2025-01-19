using Uplay.Application.Models;
using Uplay.Application.Models.Admins;
using Uplay.Application.Models.Categories;
using Uplay.Application.Models.Users;

namespace Uplay.Application.Services.Admins
{
    public interface IAdminService : IBaseService
    {
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task AddUser(CreateUserDto request);
        bool CheckIfRoleHasClaim(int roleId, int claimId);
        Task<GetAllUsersResponse> GetAllUsers(PaginationFilter paging);
        Task<GetUserDetail> GetUserDetail(int id, int userTypeId);
        Task<int> Update(int userId, CreateUserDto command);

    }
}
