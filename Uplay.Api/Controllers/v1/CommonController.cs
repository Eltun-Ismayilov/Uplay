using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Branches;
using Uplay.Application.Services.Branches;
using Uplay.Application.Services.Companys;
using Uplay.Persistence.Repository.Mongo;

namespace Uplay.Api.Controllers.v1;
[AllowAnonymous]
public class CommonController : BaseController
{
    private readonly ICoreRepo<MonthlyScanAggregate> _coreRepo;
    private readonly ICompanyService _companyService;

    public CommonController(ICoreRepo<MonthlyScanAggregate> coreRepo, ICompanyService companyService)
    {
        _coreRepo = coreRepo;
        _companyService = companyService;
    }

    [HttpGet("/qr/:branchId")]
    public async Task<ActionResult<int>> QrRetentionChekcer(int branchId)
    {
        await _coreRepo.WriteQrRetentionToCollection(branchId);
        return Created(string.Empty, "");
    }

    [HttpGet("/qr/:operationId")]
    public async Task<ActionResult<int>> QrCodeOperation(Guid operationId)
    {
        var result = await _companyService.GetOperationId(operationId);
        return Ok(result.Value);
    }

    [HttpGet("/qr/get/:branchId")]
    public async Task<ActionResult<int>> QrRetentionGet(int branchId)
    {
        return Ok(await _coreRepo.ReadQrRetention(branchId));
    }
}