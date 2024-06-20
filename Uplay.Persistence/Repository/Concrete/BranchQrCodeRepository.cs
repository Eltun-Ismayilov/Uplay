using Uplay.Domain.Entities.Models.Companies;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class BranchQrCodeRepository : BaseRepository<BranchQrCode>, IBranchQrCodeRepository
    {
        public BranchQrCodeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
