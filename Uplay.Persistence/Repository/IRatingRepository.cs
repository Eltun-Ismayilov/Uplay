using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.Repository
{
    public interface IRatingRepository : IRepository<RatingBranch>
    {
        IQueryable<RatingBranch> GetRatingsByBranch(Expression<Func<RatingBranch, bool>>? predicate);
    }
}
