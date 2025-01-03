using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Services.Companys;
using Uplay.Application.Services.Feedbacks;
using Uplay.Domain.Enums.User;
using Uplay.Persistence.Data.Statistics;
using Uplay.Persistence.Repository.Mongo;

namespace Uplay.Api.Controllers.v1;

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

    [HttpGet("/qr/:operationId")]
    public async Task<ActionResult<int>> QrCodeOperation(Guid operationId)
    {
        var result = await _companyService.GetOperationId(operationId);
        return Ok(result.Value);
    }

    [CheckPermission((int)ClaimEnum.Branch_Qr_Retention_Get)]
    [HttpGet("/qr/get/:branchId")]
    public async Task<ActionResult> QrRetentionGet([FromQuery] QrRetFilter filter)
    {
        return Ok(await _qrRetentionRepo.ReadQrRetention(filter));
    }

    [CheckPermission((int)ClaimEnum.Branch_Statistics_Get)]
    [HttpGet(ApiRoutes.FeedbackRoute.GetStatistics)]
    public async Task<ActionResult<int>> GetFeedbackStatistics([FromQuery] FilterQuery filter)
    {
        var data = await _feedbackService.GetCommonStatistics(filter);
        return Ok(data);
    }
}