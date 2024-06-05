using Microsoft.AspNetCore.Identity;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Persistence.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username);
    }
}
