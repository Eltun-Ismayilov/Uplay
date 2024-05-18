using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class AboutFileRepository : BaseRepository<AboutFile>, IAboutFileRepository
    {
        public AboutFileRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
