using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository;

public interface IReviewRepository: IRepository<Review>
{
    IQueryable<Review> GetReviewsByBranch(int id);
}