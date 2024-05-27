using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;

namespace Uplay.Api.Controllers
{
    [ApiController]
    [Validation]
   // [Authorize]
    public class BaseController : Controller { }
}
