using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class RatingRepository : Repository<RatingBranch>, IRatingRepository
    {
        public RatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<RatingBranch> GetRatingsByBranch(Expression<Func<RatingBranch, bool>>? predicate)
        {
            {
                return GetTable()
                    .AsNoTracking()
                    .Where(predicate)
                    .OrderByDescending(x => x.CreatedDate)
                    .AsQueryable();
            }
        }
    }
}