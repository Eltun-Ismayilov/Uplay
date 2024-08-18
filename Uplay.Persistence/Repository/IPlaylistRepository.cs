using System.Linq.Expressions;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Enum;

namespace Uplay.Persistence.Repository;

public interface IPlaylistRepository: IRepository<PlayList>
{
    IQueryable<PlayList> GetPlaylistsByBranch(Expression<Func<PlayList, bool>>? predicate);
    IQueryable<PlayList> GetPlaylistsInStatuses(List<PlayListEnum> statuses);
    Task<PlayList?> GetById(int id);
}