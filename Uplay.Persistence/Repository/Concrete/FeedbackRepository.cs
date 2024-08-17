using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Feedback> GetFeedbacksByBranch(Expression<Func<Feedback, bool>>? predicate)
    {
        return GetTable()
            .AsNoTracking()
            // .Include(x=>x.Branch)
            .Include(x => x.FeedbackType)
            .Where(predicate)
            .OrderByDescending(x => x.CreatedDate)
            .AsQueryable();
    }
}