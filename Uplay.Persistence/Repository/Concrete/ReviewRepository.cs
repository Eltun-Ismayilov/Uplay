using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class ReviewRepository: BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Review> GetReviewsByBranch(int id)
    {
        return GetTable().AsNoTracking().Include(x=>x.Branch).Where(x => x.BranchId == id).AsQueryable();
    }
}