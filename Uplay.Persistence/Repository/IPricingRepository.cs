using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Persistence.Repository
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        IQueryable<Pricing> GetListByPricingTypeIdQuery();
        Task<Pricing> GetByPricingId(int id);
        Task<Pricing> GetPricingById(int pricingId,int date);
    }
}
