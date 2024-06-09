using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly AppDbContext _dbContext;

        public BranchRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Branch> GetByUserId(int id)
        {
            var branch = await AsQueryable().AsNoTracking()
                .Include(x => x.Onwer)
                .FirstOrDefaultAsync(x => x.OnwerId == id);

            return branch;
        }

        public IQueryable<Branch> GetListQuery(int companyId)
        {
            var branchListquery = AsQueryable()
                .AsNoTracking()
                .Join(
                    _dbContext.CompanyBranchs,
                    branch => branch.Id,
                    companyBranchs => companyBranchs.BranchId,
                    (branch, companyBranchs) => new { Branch = branch, CompanyBranch = companyBranchs }
                )
                .Where(joinResult => joinResult.CompanyBranch.CompanyId == companyId)
                .Select(joinResult => joinResult.Branch)
                .OrderByDescending(branch => branch.Id);

            return branchListquery;
        }
    }
}