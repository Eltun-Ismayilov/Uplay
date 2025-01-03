using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Services.Citys;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Roles;

namespace Uplay.Api.Controllers.v1
{

    public class DropDownController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly IRoleService _roleService;

        public DropDownController(
            ICityService cityService,
            IRoleService roleService)
        {
            _cityService = cityService;
            _roleService = roleService;
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.CityRoute.City)]
        public async Task<IActionResult> GetCities()
        {
            var data=await _cityService.GetCities();    
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.RoleRoute.Role)]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _roleService.GetAll();
            return Ok(data);
        }
    }
}
