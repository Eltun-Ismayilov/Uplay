using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Abouts;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Services;
using Uplay.Application.Services.Abouts;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Services;

namespace Uplay.Api.Controllers.v1
{

    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpPost(ApiRoutes.AboutRoute.Create)]
        public async Task<ActionResult<int>> Create([Required][FromForm] SaveAboutRequest command)
            => Ok(await _aboutService.Create(command));


        [HttpGet(ApiRoutes.AboutRoute.Get)]
        public async Task<ActionResult<AboutGetResponse>> Get()
                => Ok(await _aboutService.Get());



        [HttpPut(ApiRoutes.AboutRoute.Update)]
        public async Task<IActionResult> Update([FromForm] SaveAboutRequest updateAboutDto)
        {
            await _aboutService.Update( updateAboutDto);
            return NoContent();
        }
    }
}
