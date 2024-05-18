using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models.SocialLinks;
using Uplay.Application.Services.SocialLinks;

namespace Uplay.Api.Controllers.v1
{
    public class SocialLinkController : BaseController
    {
        private readonly ISocialLinkService _socialLinkService;

        public SocialLinkController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }
        

        [HttpPost(ApiRoutes.SocialLinkRoute.Create)]
        public async Task<ActionResult<int>> Create([FromBody] SaveSocialLinkRequest command)
        {
            var data = await _socialLinkService.Create(command);
            return Ok(data.Value);
        }

        [HttpGet(ApiRoutes.SocialLinkRoute.Get)]
        public async Task<ActionResult<SocialLinkGetResponse>> Get()
        {
            var data = await _socialLinkService.Get();
            return Ok(data);
        }

        [HttpPut(ApiRoutes.SocialLinkRoute.Update)]
        public async Task<IActionResult> Update([Required]int id, [FromBody] SaveSocialLinkRequest updateFaqDto)
        {
            await _socialLinkService.Update(id, updateFaqDto);
            return NoContent();
        }
    }
}
