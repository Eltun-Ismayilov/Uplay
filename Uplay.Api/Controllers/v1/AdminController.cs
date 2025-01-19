using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        [AllowAnonymous]
        [HttpGet(ApiRoutes.AdminRoute.GetAllUsers)]
        //[CheckPermission((int)ClaimEnum.Get_All_Users)]
        public async Task<IActionResult> GetAllUsers([FromQuery] PaginationFilter paging)
        {
            return Ok(await _adminService.GetAllUsers(paging));
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.AdminRoute.GetUserDetail)]
        //[CheckPermission((int)ClaimEnum.Get_User_Detail)]
        public async Task<IActionResult> GetUserDetail([Required]int id, [Required] int userTypeId)
        {
            return Ok(await _adminService.GetUserDetail(id, userTypeId));
        }

        [HttpPut(ApiRoutes.AdminRoute.UpdateUser)]
        [CheckPermission((int)ClaimEnum.User_Put)]
        public async Task<IActionResult> UpdateUser([Required] int userId, [FromBody] CreateUserDto request)
        {
            await _adminService.Update(userId, request);
            return Ok();
        }
    }
}
