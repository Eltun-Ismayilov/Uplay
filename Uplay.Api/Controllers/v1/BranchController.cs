using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Branches;
using Uplay.Application.Services.Branches;

namespace Uplay.Api.Controllers.v1;

public class BranchController : BaseController
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpPost(ApiRoutes.BranchRoute.CreateBranch)]
    public async Task<ActionResult<int>> CreateCorporate([FromBody] SaveBranchRequest command)
    {
        var data = await _branchService.CreateBranchAsync(command);
        return Ok(data.Value);
    }
    
    [HttpPost(ApiRoutes.BranchRoute.DeleteBranch)]
    public async Task<ActionResult<int>> DeleteBranch([FromQuery] int id)
    {
        return Ok(await _branchService.DeleteBranch(id));
    }
    
    [HttpPost(ApiRoutes.BranchRoute.DisableBranch)]
    public async Task<ActionResult<int>> DisableBranch([FromQuery] int id)
    {
        return Ok(await _branchService.DisableBranch(id));
    }
    
    [Authorize]
    [HttpGet(ApiRoutes.BranchRoute.GetAllBranch)]
    public async Task<ActionResult<BranchGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _branchService.GetAll(paginationFilter);
        return Ok(data);
    }
    [AllowAnonymous]
    [HttpPost(ApiRoutes.BranchRoute.GetBranchIdByQrcode)]
    public async Task<ActionResult<string>> GetBranchIdByQrcode([Required][FromQuery] int id)
    {
        var data = await _branchService.GetByBranchIdAsync(id);
        return Ok(data);
    }
}