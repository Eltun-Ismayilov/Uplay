using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;
using Uplay.Persistence.Data.Statistics;

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
            .Include(x => x.FeedbackType)
            .Where(predicate)
            .OrderByDescending(x => x.CreatedDate)
            .AsQueryable();
    }


    public async Task<List<FeedbackTypeSummary>> GetFeedbackSummaryByTypeAsync(IQueryable<Feedback> queryable)
    {
        var feedbackSummary = await queryable
            .GroupBy(f => f.FeedbackType)
            .Select(x => new FeedbackTypeSummary
            {
                FeedbackType = x.Key.Name,
                TotalValue = x.Count()
            })
            .ToListAsync();

        return feedbackSummary;
    }
}