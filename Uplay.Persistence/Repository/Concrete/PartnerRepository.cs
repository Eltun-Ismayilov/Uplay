using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class PartnerRepository : Repository<Partner>, IPartnerRepository
{
    public PartnerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Partner> GetListQuery()
    {
        var faqListquery = AsQueryable().AsNoTracking()
            .Include(x => x.File)
            .OrderByDescending(x => x.Id);

        return faqListquery;
    }

    public async Task<Partner> GetPartnerByIdAsync(int id)
    {
        var partner = await AsQueryable().AsNoTracking()
            .Include(x => x.File)
            .FirstOrDefaultAsync(x => x.Id == id);

        return partner;
    }
}