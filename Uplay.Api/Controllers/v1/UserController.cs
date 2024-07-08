using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Users;
using Uplay.Application.Services.Users;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Api.Controllers.v1
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpGet("subscribe-confirm")]
        public async Task<ActionResult<int>> SubscibeConfirm(int otp)
        {
            var data = await _userService.SubscibeConfirm(otp);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var data = await _userService.Login(request);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.LoginB)]
        public async Task<IActionResult> BranchLogin([FromBody] UserLoginRequest request)
        {
            var data = await _userService.BranchLogin(request);
            return Ok(data);
        }

        [HttpPost(ApiRoutes.UserRoute.ResetPassword)]
        public async Task<IActionResult> ResetPasword([FromBody] ResetPasswordRequest request)
        {
            var data = await _userService.ResetPassword(request);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.ForgetPassword)]
        public async Task<IActionResult> ForgetPassword([FromQuery] string email)
        {
            var data = await _userService.SendForgotPasswordEmail(email);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.ConfirmForgetPassword)]
        public async Task<IActionResult> ConfirmForgetPassword([FromBody] ConfirmResetPasswordRequest request)
        {
            var data = await _userService.ConfirmResetPassword(request);
            return Ok(data);
        }
    }
}
