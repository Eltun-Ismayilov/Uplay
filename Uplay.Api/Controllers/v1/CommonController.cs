using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Services.Companys;
using Uplay.Application.Services.Feedbacks;
using Uplay.Persistence.Data.Statistics;
using Uplay.Persistence.Repository.Mongo;

namespace Uplay.Api.Controllers.v1;

[AllowAnonymous]
public class CommonController : BaseController
{
    private readonly IQrRetentionRepo _qrRetentionRepo;
    private readonly ICompanyService _companyService;
    private readonly IFeedbackService _feedbackService;

    public CommonController(IQrRetentionRepo qrRetentionRepo,
        ICompanyService companyService,
        IFeedbackService feedbackService)
    {
        _qrRetentionRepo = qrRetentionRepo;
        _companyService = companyService;
        _feedbackService = feedbackService;
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
    public async Task<ActionResult> QrRetentionGet([FromQuery] QrRetFilter filter)
    {
        return Ok(await _qrRetentionRepo.ReadQrRetention(filter));
    }

    [HttpGet(ApiRoutes.FeedbackRoute.GetStatistics)]
    public async Task<ActionResult<int>> GetFeedbackStatistics([FromQuery] FilterQuery filter)
    {
        var data = await _feedbackService.GetCommonStatistics(filter);
        return Ok(data);
    }

    // [HttpGet("/feedback/get/:branchId")]
    // public async Task<ActionResult> FeedbackRetentionGet(int branchId)
    // {
    //     return Ok(await _feedbackRetention.ReadFeedbackRetention(branchId));
    // }
    //
    // [HttpGet("/review/get/:branchId")]
    // public async Task<ActionResult> ReviewRetentionGet(int branchId)
    // {
    //     return Ok(await _feedbackRetention.ReadReviewRetention(branchId));
    // }
}