using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Enums;

namespace Uplay.Persistence.Repository;

public interface IPlaylistRepository: IRepository<PlayList>
{
    IQueryable<PlayList> GetPlaylistsByBranch(Expression<Func<PlayList, bool>>? predicate);
    IQueryable<PlayList> GetPlaylistsInStatuses(int branchId, List<PlayListEnum> statuses);
    Task<PlayList?> GetById(int id);
    Task<IQueryable<PlayList>> GetTop3PlaylistsByPlays(int branchId);
}