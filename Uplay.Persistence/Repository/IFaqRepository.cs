using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Persistence.Repository;

public interface IFaqRepository : IRepository<Faq>
{
    IQueryable<Faq> GetListQuery();
}