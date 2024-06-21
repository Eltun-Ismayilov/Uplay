using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Persistence.Repository.Mongo;

namespace Uplay.Api.Controllers.v1;
[AllowAnonymous]
public class CommonController: BaseController
{
    private readonly ICoreRepo<MonthlyScanAggregate> _coreRepo;

    public CommonController(ICoreRepo<MonthlyScanAggregate> coreRepo)
    {
        _coreRepo = coreRepo;
    }

    [HttpGet("/qr/:branchId")]
    public async Task<ActionResult<int>> QrRetentionChekcer(int branchId)
    {
        await _coreRepo.WriteQrRetentionToCollection(branchId);
        return Created(string.Empty, "");
    }
    
    [HttpGet("/qr/get/:branchId")]
    public async Task<ActionResult<int>> QrRetentionGet(int branchId)
    {
        return Ok(await _coreRepo.ReadQrRetention(branchId));
    }
}