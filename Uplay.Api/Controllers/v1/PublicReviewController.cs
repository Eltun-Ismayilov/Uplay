using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.PublicReviews;
using Uplay.Application.Services.PublicReviews;

namespace Uplay.Api.Controllers.v1
{
    public class PublicReviewController : BaseController
    {
        private readonly IPublicReviewService _publicReviewService;

        public PublicReviewController(IPublicReviewService publicReviewService)
        {
            _publicReviewService = publicReviewService;
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.PublicReviewRoute.GetAll)]
        public async Task<ActionResult<PublicReviewGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var data = await _publicReviewService.GetAll(paginationFilter);
            return Ok(data);
        }

        [HttpPost(ApiRoutes.PublicReviewRoute.Create)]
        public async Task<ActionResult<int>> Create([FromForm] SavePublicReviewRequest command)
        {
            var data = await _publicReviewService.Create(command);
            return Ok(data.Value);
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.PublicReviewRoute.Get)]
        public async Task<ActionResult<PublicReviewGetResponse>> Get([Required] int id)
        {
            var data = await _publicReviewService.Get(id);
            return Ok(data);
        }

        [HttpDelete(ApiRoutes.PublicReviewRoute.Delete)]
        public async Task<IActionResult> Delete([Required] int id)
        {
            await _publicReviewService.Delete(id);
            return NoContent();
        }

        [HttpPut(ApiRoutes.PublicReviewRoute.Update)]
        public async Task<IActionResult> Update(int id, [FromForm] SavePublicReviewRequest request)
        {
            await _publicReviewService.Update(id, request);
            return NoContent();
        }
    }
}
