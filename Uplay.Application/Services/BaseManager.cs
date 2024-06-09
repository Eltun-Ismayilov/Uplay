using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Uplay.Application.Services.Users;

namespace Uplay.Application.Services
{
    public class BaseManager
    {
        protected readonly IHttpContextAccessor HttpContextAccessor;

        protected readonly IMapper Mapper;

        private readonly IUserService _authService;
        protected string Username => _authService.Username;
        protected BaseManager(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
            _authService = httpContextAccessor.HttpContext?.RequestServices?.GetRequiredService<IUserService>() ??
                           throw new ArgumentException("Auth service can't be null");
        }
        
        protected BaseManager(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
