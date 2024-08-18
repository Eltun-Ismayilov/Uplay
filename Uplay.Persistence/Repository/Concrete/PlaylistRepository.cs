using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Enum;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete;

public class PlaylistRepository : Repository<PlayList>, IPlaylistRepository
{
    public PlaylistRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<PlayList> GetPlaylistsByBranch(Expression<Func<PlayList, bool>>? predicate)
    {
        {
            return GetTable()
                .AsNoTracking()
                .Where(predicate)
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();
        }
    }
    
    public Task<PlayList?> GetById(int id)
    {
        {
            return GetTable()
                .AsNoTracking()
                .Where(x=> x.Id == id)
                .Include(x=>x.PlayListStatusHistories)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync();
        }
    }

    public IQueryable<PlayList> GetPlaylistsInStatuses(List<PlayListEnum> statuses)
    {
        {
            return GetTable()
                .AsNoTracking()
                .Include(x=>x.File)
                .Where(x => statuses.Contains(x.Status))
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();
        }
    }
}