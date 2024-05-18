using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<About> GetByAboutIdQuery(int id)
        {
            var about = await AsQueryable().AsNoTracking()
                  .Include(x => x.AboutTypes)
                    .ThenInclude(x => x.File)
                  .Include(x => x.AboutFiles)
                   .ThenInclude(x => x.File)
                  .FirstOrDefaultAsync(x => x.Id == id);

            return about;
        }

        public async Task<About> GetQuery()
        {
            var about = await AsQueryable().AsNoTracking()
                .Include(x => x.AboutTypes)
                  .ThenInclude(x => x.File)
                .Include(x => x.AboutFiles)
                 .ThenInclude(x => x.File)
                .FirstOrDefaultAsync();

            return about;
        }
    }
}
