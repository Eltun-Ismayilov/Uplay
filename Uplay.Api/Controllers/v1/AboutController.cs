using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Abouts;
using Uplay.Application.Services.Abouts;

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
        {
            var data = await _aboutService.Create(command);
            return Ok(data.Value);
        }
    }
}
