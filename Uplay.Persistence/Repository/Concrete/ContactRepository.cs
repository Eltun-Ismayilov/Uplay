using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class ContactRepository: Repository<Contact>, IContactRepository
{
    public ContactRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public IQueryable<Contact> GetListQuery()
    {
        var contactListquery = AsQueryable().AsNoTracking()
            .OrderByDescending(x => x.Id);

        return contactListquery;
    }
}