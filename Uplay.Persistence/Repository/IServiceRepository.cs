using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository
{
    public interface IServiceRepository : IRepository<Service>
    {
        IQueryable<Service> GetListQuery();
        Task<Service> GetServiceByIdAsync(int id);
    }
}
