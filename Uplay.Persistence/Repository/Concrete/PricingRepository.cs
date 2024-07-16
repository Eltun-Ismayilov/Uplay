using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Pricings;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class PricingRepository : BaseRepository<Pricing>, IPricingRepository
    {
        public PricingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pricing> GetByPricingId(int id)
        {
            var pricing = await AsQueryable().AsNoTracking()
                .Include(x => x.PricingType)
                .Include(x => x.PricingSections)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            return pricing;
        }

        public IQueryable<Pricing> GetListByPricingTypeIdQuery()
        {
            var pricingListquery = AsQueryable().AsNoTracking()
                .Include(x => x.PricingType)
                .Include(x => x.PricingSections);

            return pricingListquery;
        }

        public async Task<Pricing?> GetPricingById(int pricingId, int date)
        {
            int checkId = date == 1 ? 1 : 12;

            var pricingListquery = await AsQueryable().AsNoTracking()
                 .Include(x => x.PricingType)
                 .Include(x => x.PricingSections)
                 .FirstOrDefaultAsync(x => x.Monthly == checkId && x.Id == pricingId);

            return pricingListquery;
        }
    }
}
