using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Persistence.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> SubscibeConfirmByCompanyId(int id);
        Task<Company> GetByUserId(int userId);
    }
}
