using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Playlists;
using Uplay.Domain.Enum;

namespace Uplay.Application.Services.Playlists;

public interface IPlaylistService : IBaseService
{
    Task<ActionResult<int>> Create(SavePlaylistRequest command);
    Task Update(int id, PlayListEnum statusId);
    Task<GetAllPlaylistResponse> getAllByStatuses(List<PlayListEnum> statuses, PaginationFilter paginationFilter);
    Task<GetAllPlaylistResponse> getTopThreeMusic(int branchId);
}