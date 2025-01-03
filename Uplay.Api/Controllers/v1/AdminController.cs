using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Admins;
using Uplay.Application.Models.Users;
using Uplay.Application.Services.Admins;
using Uplay.Domain.Enums.User;
using Uplay.Domain.Extension;

namespace Uplay.Api.Controllers.v1
{

    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.AdminRoute.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var data = await _adminService.Login(request);
            return Ok(data);
        }


        [HttpPost(ApiRoutes.AdminRoute.Register)]
        [CheckPermission((int)ClaimEnum.Add_User_Post)]
        public async Task<IActionResult> Register([FromBody] CreateUserDto request)
        {
            await _adminService.AddUser(request);
            return Ok();
        }

        [HttpPost(ApiRoutes.AdminRoute.GetAllUsers)]
        [CheckPermission((int)ClaimEnum.Get_All_Users)]
        public async Task<IActionResult> GetAllUsers([FromQuery]PaginationFilter paging)
        {
            return Ok(await _adminService.GetAllUsers(paging));
        }
    }
}
