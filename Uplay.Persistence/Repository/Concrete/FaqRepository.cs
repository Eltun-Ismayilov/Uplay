using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class FaqRepository : BaseRepository<Faq>, IFaqRepository
{
    public FaqRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Faq> GetListQuery()
    {
        var faqListquery = AsQueryable().AsNoTracking()
            .OrderByDescending(x => x.Id);

        return faqListquery;
    }
}