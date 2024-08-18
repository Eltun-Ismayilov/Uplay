using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository;

public interface IReviewRepository: IRepository<Review>
{
    IQueryable<Review> GetReviewsByBranch(Expression<Func<Review, bool>>? predicate);
}