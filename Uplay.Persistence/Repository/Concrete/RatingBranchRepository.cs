using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class RatingBranchRepository : BaseRepository<RatingBranch>, IRatingBranchRepository
    {
        public RatingBranchRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
