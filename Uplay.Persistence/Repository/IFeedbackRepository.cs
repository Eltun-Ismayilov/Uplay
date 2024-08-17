using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository;

public interface IFeedbackRepository : IRepository<Feedback>
{
    IQueryable<Feedback>? GetFeedbacksByBranch(Expression<Func<Feedback, bool>>? predicate);
}