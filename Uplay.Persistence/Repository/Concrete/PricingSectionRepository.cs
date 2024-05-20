using Uplay.Domain.Entities.Models.Pricings;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class PricingSectionRepository : BaseRepository<PricingSection>, IPricingSectionRepository
    {
        public PricingSectionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
