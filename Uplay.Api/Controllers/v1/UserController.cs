using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Users;
using Uplay.Application.Services.Users;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1
{
    public class UserController : BaseController
    {
        private readonly IAdminService _userService;

        public UserController(IAdminService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpGet("subscribe-confirm")]
        public async Task<ActionResult<int>> SubscibeConfirm(int otp)
        {
            var data = await _userService.SubscibeConfirm(otp);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.UserRoute.SendOtp)]
        public async Task<ActionResult<int>> SendOtp(string emailAddress)
        {
            var data = await _userService.SendOtpAsync(emailAddress);
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

        [CheckPermission((int)ClaimEnum.Branch_Delete)]
        [HttpDelete(ApiRoutes.UserRoute.DeleteBranchAccount)]
        public async Task<IActionResult> DeleteBranchAccount(int branchId)
        {
            await _userService.DeleteBranchAccount(branchId);
            return NoContent();
        }

        [CheckPermission((int)ClaimEnum.Company_Delete)]
        [HttpDelete(ApiRoutes.UserRoute.DeleteCompanyAccount)]
        public async Task<IActionResult> DeleteCompanyAccount(int companyId)
        {
            await _userService.DeleteCorporateAccount(companyId);
            return NoContent();
        }
         
   //     [AllowAnonymous]
        [HttpGet(ApiRoutes.UserRoute.GetBranchAccountInfo)]
        public async Task<IActionResult> GetBranchAccountInfo(int branchId)
        {
            return Ok(await _userService.GetBranchAccountInfo(branchId));
        }
        
        [AllowAnonymous]
        [HttpGet(ApiRoutes.UserRoute.GetCompanyAccountInfo)]
        public async Task<IActionResult> GetCompanyAccountInfo(int companyId)
        {
            return Ok(await _userService.GetCompanyAccountInfo(companyId));
        }
        
        [AllowAnonymous]
        [HttpPut(ApiRoutes.UserRoute.UpdateBranchAccountInfo)]
        public async Task<IActionResult> UpdateBranchAccountInfo(int branchId, BranchAccountRequest request)
        {
            await _userService.UpdateBranchAccountInfo(branchId, request);
            return NoContent();
        }
        
        [AllowAnonymous]
        [HttpPut(ApiRoutes.UserRoute.UpdateCompanyAccountInfo)]
        public async Task<IActionResult> UpdateCompanyAccountInfo(int companyId, BranchAccountRequest request)
        {
            await _userService.UpdateCompanyAccountInfo(companyId, request);
            return NoContent();
        }
    }
}
