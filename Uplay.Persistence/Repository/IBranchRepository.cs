using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.Repository
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<Branch> GetByUserId(int id);
        IQueryable<Branch> GetListQuery(int companyId);
    }
}