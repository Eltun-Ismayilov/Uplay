using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class AboutTypeRepository : BaseRepository<AboutType>, IAboutTypeRepository
    {
        public AboutTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
