using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data.Statistics;

namespace Uplay.Persistence.Repository;

public interface IFeedbackRepository : IRepository<Feedback>
{
    IQueryable<Feedback>? GetFeedbacksByBranch(Expression<Func<Feedback, bool>>? predicate);
    Task<List<FeedbackTypeSummary>> GetFeedbackSummaryByTypeAsync(IQueryable<Feedback> queryable);
}