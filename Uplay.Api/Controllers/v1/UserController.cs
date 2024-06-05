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
        public async Task<ActionResult<int>> SubscibeConfirm(string token)
        {
            var data = await _userService.SubscibeConfirm(token);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var data = await _userService.Login(request);
            return Ok(data);
        }
    }
}
