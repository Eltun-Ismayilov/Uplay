using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class CompanyBranchRepository : BaseRepository<CompanyBranch>, ICompanyBranchRepository
    {
        public CompanyBranchRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
