using Uplay.Domain.Entities.Models.Companies;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
