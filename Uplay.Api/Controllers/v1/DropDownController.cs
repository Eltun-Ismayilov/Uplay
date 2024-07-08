using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Services.Citys;
using Uplay.Application.Services.Faqs;

namespace Uplay.Api.Controllers.v1
{

    public class DropDownController : BaseController
    {
        private readonly ICityService _cityService;

        public DropDownController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.CityRoute.City)]
        public async Task<IActionResult> GetCities()
        {
            var data=await _cityService.GetCities();    
            return Ok(data);
        }
    }
}
