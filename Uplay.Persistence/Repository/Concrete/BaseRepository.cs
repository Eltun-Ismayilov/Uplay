using Uplay.Domain.Entities;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class BaseRepository<T> : Repository<T> where T : BaseEntity, ISoftDeletedEntity, IUpdatedDateEntity
    {
        protected BaseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
