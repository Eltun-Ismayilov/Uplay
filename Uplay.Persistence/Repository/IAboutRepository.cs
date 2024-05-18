using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository
{
    public interface IAboutRepository : IRepository<About>
    {
       Task<About> GetQuery();
    }
}
