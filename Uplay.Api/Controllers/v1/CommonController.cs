using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Persistence.Repository.Mongo;
using Uplay.Persistence.Repository.Mongo.FeedbackRetention;

namespace Uplay.Api.Controllers.v1;
[AllowAnonymous]
public class CommonController: BaseController
{
    private readonly IQrRetentionRepo<MonthlyScanAggregate> _qrRetentionRepo;
    private readonly IFeedbackRetention _feedbackRetention;

    public CommonController(IQrRetentionRepo<MonthlyScanAggregate> qrRetentionRepo, IFeedbackRetention feedbackRetention)
    {
        _qrRetentionRepo = qrRetentionRepo;
        _feedbackRetention = feedbackRetention;
    }

    [HttpGet("/qr/:branchId")]
    public async Task<ActionResult<int>> QrRetentionChekcer(int branchId)
    {
        await _qrRetentionRepo.WriteQrRetentionToCollection(branchId);
        return Created(string.Empty, "");
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