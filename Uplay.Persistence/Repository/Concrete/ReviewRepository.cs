using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class ReviewRepository : BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Review> GetReviewsByBranch(Expression<Func<Review, bool>>? predicate)
    {
        return GetTable().AsNoTracking().Where(predicate).OrderByDescending(x => x.CreatedDate).AsQueryable();
    }
}