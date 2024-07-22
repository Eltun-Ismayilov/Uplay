using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;
using Uplay.Application.Services.Feedbacks;

namespace Uplay.Api.Controllers.v1;

[AllowAnonymous]
public class FeedbackTypeController : BaseController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackTypeController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpGet(ApiRoutes.FeedbackTypeRoute.GetAll)]
    public async Task<ActionResult<FeedbackGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _feedbackService.GetAllFeedbackTypes(paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.FeedbackTypeRoute.Create)]
    public async Task<ActionResult<int>> Create([FromBody] SaveFeedbackTypeRequest command)
    {
        var data = await _feedbackService.CreateFeedbackType(command);
        return Ok(data.Value);
    }
    
    [HttpDelete(ApiRoutes.FeedbackTypeRoute.Delete)]
    public async Task<IActionResult> Delete([Required] int id)
    {
        await _feedbackService.DeleteFeedbackType(id);
        return NoContent();
    }

    [HttpPut(ApiRoutes.FeedbackTypeRoute.Update)]
    public async Task<IActionResult> Update(int id, [FromForm] SaveFeedbackTypeRequest command)
    {
        await _feedbackService.UpdateFeedbackType(id, command);
        return NoContent();
    }
}