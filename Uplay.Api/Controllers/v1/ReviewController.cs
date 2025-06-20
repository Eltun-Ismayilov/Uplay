﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Reviews;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1;

[AllowAnonymous]
public class ReviewController : BaseController
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet(ApiRoutes.ReviewRoute.GetAll)]
    public async Task<ActionResult<ReviewGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter, [FromQuery] ReviewFilter filter)
    {
        var data = await _reviewService.GetAll(filter, paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.ReviewRoute.Create)]
    public async Task<ActionResult<int>> Create([FromForm] SaveReviewRequest command)
    {
        var data = await _reviewService.Create(command);
        return Ok(data.Value);
    }
    [AllowAnonymous]

   // [CheckPermission((int)ClaimEnum.Review_Put)]
    [HttpPut(ApiRoutes.ReviewRoute.Update)]
    public async Task<IActionResult> Update(int reviewId, [FromBody] SaveReviewRequest request)
    {
        await _reviewService.Update(reviewId, request);
        return NoContent();
    }
}