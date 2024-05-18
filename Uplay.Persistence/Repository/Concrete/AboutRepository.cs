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

        public IQueryable<About> GetListQuery()
        {
            var aboutListquery = AsQueryable().AsNoTracking()
                .OrderByDescending(x => x.Id);

            return aboutListquery;
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
