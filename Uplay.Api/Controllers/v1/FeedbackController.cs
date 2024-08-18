using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;
using Uplay.Application.Services.Feedbacks;

namespace Uplay.Api.Controllers.v1;

[AllowAnonymous]
public class FeedbackController : BaseController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpGet(ApiRoutes.FeedbackRoute.GetAll)]
    public async Task<ActionResult<FeedbackGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter,
        [FromQuery] FeedbackFilter filter)
    {
        var data = await _feedbackService.GetAll(filter, paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.FeedbackRoute.Create)]
    public async Task<ActionResult<int>> Create([FromBody] SaveFeedbackRequest command)
    {
        var data = await _feedbackService.Create(command);
        return Ok(data.Value);
    }
}