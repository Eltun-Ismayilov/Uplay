﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Feedbacks;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Feedbacks;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1;

public class FeedbackTypeController : BaseController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackTypeController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [AllowAnonymous]
    [HttpGet(ApiRoutes.FeedbackTypeRoute.GetAll)]
    public async Task<ActionResult<FeedbackTypeGetAllReponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _feedbackService.GetAllFeedbackTypes(paginationFilter);
        return Ok(data);
    }

    [AllowAnonymous]
    [HttpGet(ApiRoutes.FeedbackTypeRoute.Get)]
    public async Task<ActionResult<FeedbackTypeGetResponse>> Get([Required] int id)
    {
        var data = await _feedbackService.Get(id);
        return Ok(data);
    }


    [CheckPermission((int)ClaimEnum.FeedbackType_Post)]
    [HttpPost(ApiRoutes.FeedbackTypeRoute.Create)]
    public async Task<ActionResult<int>> Create([FromBody] SaveFeedbackTypeRequest command)
    {
        var data = await _feedbackService.CreateFeedbackType(command);
        return Ok(data.Value);
    }

    [CheckPermission((int)ClaimEnum.FeedbackType_Delete)]
    [HttpDelete(ApiRoutes.FeedbackTypeRoute.Delete)]
    public async Task<IActionResult> Delete([Required] int id)
    {
        await _feedbackService.DeleteFeedbackType(id);
        return NoContent();
    }

    [CheckPermission((int)ClaimEnum.FeedbackType_Put)]
    [HttpPut(ApiRoutes.FeedbackTypeRoute.Update)]
    public async Task<IActionResult> Update(int id, [FromForm] SaveFeedbackTypeRequest command)
    {
        await _feedbackService.UpdateFeedbackType(id, command);
        return NoContent();
    }
}