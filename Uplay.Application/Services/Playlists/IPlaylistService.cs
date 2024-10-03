using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Application.Models.Playlists;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Enum;

namespace Uplay.Application.Services.Playlists;

public interface IPlaylistService : IBaseService
{
    Task<ActionResult<int>> Create(SavePlaylistRequest command);
    Task Update(int id, PlayListEnum statusId);
    Task<GetAllPlaylistResponse> getAllByStatuses(ReviewFilter filter, List<PlayListEnum> statuses, PaginationFilter paginationFilter);
    Task<GetAllPlaylistResponse> getTopThreeMusic(int branchId);
}