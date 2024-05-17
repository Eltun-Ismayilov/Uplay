using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class AboutRepository :BaseRepository<About>, IAboutRepository
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
    }
}
