using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Services.Users;

namespace Uplay.Api.Controllers.v1
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)=> _userService=userService;


        [HttpGet(ApiRoutes.UserRoute.SubscribeConfirm)]
        public async Task<ActionResult<int>> SubscibeConfirm(string token)
        {
            var data = await _userService.SubscibeConfirm(token);
            return Ok(data);
        }
    }
}
