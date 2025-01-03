using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Enums;

namespace Uplay.Persistence.Repository
{
    public interface IServiceRepository : IRepository<Service>
    {
        IQueryable<Service> GetListByServiceTypeIdQuery(ServiceTypeEnum serviceTypeId);
        Task<Service> GetServiceByIdAsync(int id);
    }
}
