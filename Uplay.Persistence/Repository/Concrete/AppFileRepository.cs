using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class AppFileRepository : BaseRepository<AppFile>
    {
        public AppFileRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
