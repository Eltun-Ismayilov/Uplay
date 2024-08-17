using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class RatingRepository : Repository<RatingBranch>, IRatingRepository
    {
        public RatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
