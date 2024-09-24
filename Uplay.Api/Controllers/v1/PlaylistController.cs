using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Feedbacks;
using Uplay.Application.Models.Playlists;
using Uplay.Application.Services.Playlists;
using Uplay.Domain.Enum;

namespace Uplay.Api.Controllers.v1;

[AllowAnonymous]
public class PlaylistController : BaseController
{
    private readonly IPlaylistService _playlistService;

    public PlaylistController(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    [HttpGet(ApiRoutes.PlaylistRoute.GetAll)]
    public async Task<ActionResult<FeedbackGetAllResponse>> GetAll([FromQuery] int branchId, [FromQuery] PaginationFilter paginationFilter,
        [FromQuery] List<PlayListEnum> statuses)
    {
        var data = await _playlistService.getAllByStatuses(branchId, statuses, paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.PlaylistRoute.Create)]
    public async Task<ActionResult<int>> Create([FromForm] SavePlaylistRequest command)
    {
        var data = await _playlistService.Create(command);
        return Ok(data.Value);
    }

    [HttpPut(ApiRoutes.PlaylistRoute.Update)]
    public async Task<ActionResult<int>> Update(int id, [FromQuery] PlayListEnum status)
    {
        await _playlistService.Update(id, status);
        return NoContent();
    }
    
    [HttpGet(ApiRoutes.PlaylistRoute.Topthree)]
    public async Task<ActionResult<int>> Topthree(int branchId)
    {
        return Ok(await _playlistService.getTopThreeMusic(branchId));
    }
}