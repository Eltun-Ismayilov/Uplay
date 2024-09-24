using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Persistence.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByUsernameWithBranch(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> CheckUser(Expression<Func<User, bool>> predicate);
        Task<User> CheckOtpCode(int optCode);
    }
}