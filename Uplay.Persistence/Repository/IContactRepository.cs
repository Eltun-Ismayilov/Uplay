using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository;

public interface IContactRepository:IRepository<Contact>
{
    IQueryable<Contact> GetListQuery();
}