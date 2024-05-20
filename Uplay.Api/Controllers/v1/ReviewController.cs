//using Microsoft.AspNetCore.Mvc;
//using Uplay.Api.Contracts;
//using Uplay.Application.Models;
//using Uplay.Application.Models.Core.Reviews;
//using Uplay.Application.Models.Faqs;
//using Uplay.Application.Services.Reviews;

//namespace Uplay.Api.Controllers.v1;

//public class ReviewController : BaseController
//{
//    private readonly IReviewService _reviewService;

//    public ReviewController(IReviewService reviewService)
//    {
//        _reviewService = reviewService;
//    }

//    [HttpGet(ApiRoutes.ReviewRoute.GetAll)]
//    public async Task<ActionResult<FaqGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter, int id)
//    {
//        var data = await _reviewService.GetAll(id, paginationFilter);
//        return Ok(data);
//    }

//    [HttpPost(ApiRoutes.ReviewRoute.Create)]
//    public async Task<ActionResult<int>> Create([FromForm] SaveReviewRequest command)
//    {
//        var data = await _reviewService.Create(command);
//        return Ok(data.Value);
//    }
//}