using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
            var user = await AsQueryable()
                              .FirstOrDefaultAsync(x => x.UserName == username || x.Email == username);

            return user;
        }
        
        public async Task<User> GetUserByUsernameWithBranch(string username)
        {
            var user = await AsQueryable().AsNoTracking()
                .Include(x=>x.Branches)
                .Include(x=>x.Companies)
                .FirstOrDefaultAsync(x => x.UserName == username || x.Email == username);

            return user;
        }
        
        public async Task<User> GetUserByUsername(string username)
        {
            var user = await AsQueryable().AsNoTracking()
                .Include(x=>x.Companies)
                .FirstOrDefaultAsync(x => x.UserName == username || x.Email == username);

            return user;
        }
        
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await AsQueryable()
                .FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }
        
        public async Task<User> CheckUser(Expression<Func<User, bool>> predicate)
        {
            var user = await AsQueryable().AsNoTracking()
                .FirstOrDefaultAsync(predicate);

            return user;
        }

        public async Task<User?> CheckOtpCode(int optCode)
        {
            var user = await AsQueryable()
                              .FirstOrDefaultAsync(x => x.OtpCode==optCode);

            return user;
        }
    }
}
