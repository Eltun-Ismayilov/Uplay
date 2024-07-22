using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Ratings;
using Uplay.Application.Services.Ratings;

namespace Uplay.Api.Controllers.v1
{
    [AllowAnonymous]

    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost(ApiRoutes.RatingRoute.Create)]
        public async Task<ActionResult<int>> Create([FromBody] SaveRatingRequest command)
        {
            var data = await _ratingService.Create(command);
            return Ok(data.Value);
        }
    }
}
