using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Uplay.Application.Services
{
    public class BaseManager
    {
        protected readonly IHttpContextAccessor HttpContextAccessor;

        protected readonly IMapper Mapper;

        // private readonly IAuthService _authService;
        // protected int UserId => _authService.UserId;
        protected BaseManager(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
            //_authService = httpContextAccessor.HttpContext?.RequestServices?.GetService<IAuthService>() ??
            //               throw new ArgumentException("Auth service can't be null");
        }

    }
}
