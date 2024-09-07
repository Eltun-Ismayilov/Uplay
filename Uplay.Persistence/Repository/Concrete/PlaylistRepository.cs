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
                .Where(x => x.Id == id)
                .Include(x => x.PlayListStatusHistories)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync();
        }
    }

    public IQueryable<PlayList> GetPlaylistsInStatuses(List<PlayListEnum> statuses)
    {
        {
            return GetTable()
                .AsNoTracking()
                .Include(x => x.File)
                .Where(x => statuses.Contains(x.Status))
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();
        }
    }

    public async Task<IQueryable<PlayList>> GetTop3PlaylistsByPlays(int branchId)
    {
        var last7Days = DateTime.UtcNow.AddDays(-7);

        var query = await GetTable()
            .AsNoTracking()
            .Include(p => p.PlayListStatusHistories)
            .Where(p => p.Status == PlayListEnum.Approved && p.CreatedDate.Date >= last7Days &&
                        p.BranchId == branchId)
            .GroupBy(p => new 
            { 
                p.Id,
                p.Title,
                p.FileId,
                p.Duration,
                p.BranchId
            })
            .Select(g => new
            {
                PlaylistId = g.Key.Id,
                Title = g.Key.Title,
                FileId = g.Key.FileId,
                Duration = g.Key.Duration,
                BranchId = g.Key.BranchId,
                DistinctYoutubeIdCount = g.Select(p => p.YoutubeId).Count()
            })
            .OrderByDescending(g => g.DistinctYoutubeIdCount)
            .Take(3) 
            .ToListAsync();

        var playlistIds = query.Select(pl => pl.PlaylistId).ToList();

        var topPlaylists = GetTable()
            .AsNoTracking()
            .Where(p => playlistIds.Contains(p.Id))
            .OrderByDescending(p => playlistIds.IndexOf(p.Id));
        return topPlaylists;
    }
}