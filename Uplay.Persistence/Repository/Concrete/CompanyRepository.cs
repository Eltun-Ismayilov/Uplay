﻿using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Company> GetByUserId(int id)
        {
            var company = await AsQueryable().AsNoTracking()
                  .Include(x => x.Onwer)
                  .FirstOrDefaultAsync(x => x.OnwerId == id);

            return company;
        }

        public async Task<Company> SubscibeConfirmByCompanyId(int companyId)
        {
            var company = await AsQueryable().AsNoTracking()
                      .Include(x => x.Onwer)
                      .FirstOrDefaultAsync(x => x.Id == companyId);

            return company;
        }
    }
}
