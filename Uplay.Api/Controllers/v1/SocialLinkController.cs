using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models.SocialLinks;
using Uplay.Application.Services.SocialLinks;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1
{
    public class SocialLinkController : BaseController
    {
        private readonly ISocialLinkService _socialLinkService;

        public SocialLinkController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }

        [CheckPermission((int)ClaimEnum.SocialLink_Post)]
        [HttpPost(ApiRoutes.SocialLinkRoute.Create)]
        public async Task<ActionResult<int>> Create([FromBody] SaveSocialLinkRequest command)
        {
            var data = await _socialLinkService.Create(command);
            return Ok(data.Value);
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.SocialLinkRoute.Get)]
        public async Task<ActionResult<SocialLinkGetResponse>> Get()
        {
            var data = await _socialLinkService.Get();
            return Ok(data);
        }

        [CheckPermission((int)ClaimEnum.SocialLink_Put)]
        [HttpPut(ApiRoutes.SocialLinkRoute.Update)]
        public async Task<IActionResult> Update([Required]int id, [FromBody] SaveSocialLinkRequest updateFaqDto)
        {
            await _socialLinkService.Update(id, updateFaqDto);
            return NoContent();
        }
    }
}
