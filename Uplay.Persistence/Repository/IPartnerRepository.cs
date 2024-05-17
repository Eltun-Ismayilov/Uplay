using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository;

public interface IPartnerRepository : IRepository<Partner>
{
    IQueryable<Partner> GetListQuery();
    Task<Partner> GetPartnerByIdAsync(int id);
}