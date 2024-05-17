using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Service> GetListQuery()
        {
            var serviceListquery = AsQueryable().AsNoTracking()
                .Include(x => x.File)
                .Include(x=>x.ServiceType)
                .OrderByDescending(x => x.Id);

            return serviceListquery;
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            var service = await AsQueryable().AsNoTracking()
                .Include(x => x.File)
                .Include(x=>x.ServiceType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return service;
        }
    }
}
