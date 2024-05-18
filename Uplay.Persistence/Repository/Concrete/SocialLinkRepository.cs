using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class SocialLinkRepository : BaseRepository<SocialLink>, ISocialLinkRepository
    {
        public SocialLinkRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<SocialLink> GetQuery()
        {
            var socialLink = await AsQueryable().AsNoTracking()
                .FirstOrDefaultAsync();

            return socialLink;
        }
    }
}
