using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Branches;
using Uplay.Application.Services.Branches;
using Uplay.Application.Services.Companys;
using Uplay.Persistence.Repository.Mongo;
using Uplay.Persistence.Repository.Mongo.FeedbackRetention;

namespace Uplay.Api.Controllers.v1;

public class CommonController : BaseController
{
    private readonly IQrRetentionRepo<MonthlyScanAggregate> _qrRetentionRepo;
    private readonly IFeedbackRetention _feedbackRetention;
    private readonly ICompanyService _companyService;

    public CommonController(IQrRetentionRepo<MonthlyScanAggregate> qrRetentionRepo,
        IFeedbackRetention feedbackRetention,
        ICompanyService companyService)
    {
        _qrRetentionRepo = qrRetentionRepo;
        _feedbackRetention = feedbackRetention;
        _companyService = companyService;
    }

    [HttpGet("/qr/:branchId")]
    public async Task<ActionResult<int>> QrRetentionChekcer(int branchId)
    {
        await _qrRetentionRepo.WriteQrRetentionToCollection(branchId);
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
        return Ok(await _qrRetentionRepo.ReadQrRetention(branchId));
    }

    [HttpGet("/feedback/get/:branchId")]
    public async Task<ActionResult<int>> FeedbackRetentionGet(int branchId)
    {
        return Ok(await _feedbackRetention.ReadFeedbackRetention(branchId));
    }

    [HttpGet("/review/get/:branchId")]
    public async Task<ActionResult<int>> ReviewRetentionGet(int branchId)
    {
        return Ok(await _feedbackRetention.ReadReviewRetention(branchId));
    }
}