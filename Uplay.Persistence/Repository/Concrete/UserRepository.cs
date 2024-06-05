using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Login(string username)
        {
            var user = await AsQueryable().AsNoTracking()
                              .FirstOrDefaultAsync(x => x.UserName == username || x.Email == username);

            return user;
        }
    }
}
