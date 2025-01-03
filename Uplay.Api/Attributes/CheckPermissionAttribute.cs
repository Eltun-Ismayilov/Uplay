using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using Uplay.Application.Exceptions;
using Uplay.Application.Services.Admins;

namespace Uplay.Api.Attributes;

public class CheckPermissionAttribute : Attribute, IAsyncActionFilter
{
    private int claimId;
    public CheckPermissionAttribute(int claimId)
    {
        this.claimId = claimId;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var adminService = context.HttpContext.RequestServices.GetService<IAdminService>();
      
        context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

        token = token.ToString().Split(" ")[1];

        JwtSecurityTokenHandler tokenHandler = new();
        JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

        var roleId = jwtToken.Claims.First(claim => claim.Type == "Role").Value;

        if (!adminService.CheckIfRoleHasClaim(Int32.Parse(roleId), claimId))
            throw new UnauthorizedException("Bu emeliyyati icra etmek uchun icazeniz yoxdur.");

        await next();
    }
}
