using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Services.Feedbacks;
using Uplay.Application.Services.RatingBranchs;

namespace Uplay.Api.Controllers.v1
{
    [AllowAnonymous]
    public class RatingBranchController : BaseController
    {
        private readonly IRatingBranchService _ratingBranchService;

        public RatingBranchController(IRatingBranchService ratingBranchService)
        {
            _ratingBranchService = ratingBranchService;
        }

        [HttpGet(ApiRoutes.RatingBranchRoute.Get)]
        public async Task<ActionResult<FaqGetResponse>> Get([Required] int branchId)
        {
            var data = await _ratingBranchService.Get(branchId);
            return Ok(data);
        }

        [HttpGet(ApiRoutes.RatingBranchRoute.GetStatistics)]
        public async Task<ActionResult<int>> GetRatingBranchStatistics([FromQuery] FilterRatingBranchQuery filter)
        {
            var data = await _ratingBranchService.GetCommonStatistics(filter);
            return Ok(data);
        }
    }
}
