using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Persistence.Repository
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        IQueryable<Pricing> GetListByPricingTypeIdQuery(int pricingTypeId);
        Task<Pricing> GetByPricingId(int id);
    }
}
