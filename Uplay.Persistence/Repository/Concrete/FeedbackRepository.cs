using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class FeedbackRepository: BaseRepository<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Feedback> GetFeedbacksByBranch(int id)
    {
       return GetTable().AsNoTracking().Include(x=>x.Branch).Where(x => x.BranchId == id).AsQueryable();
    }
}