using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;

namespace Uplay.Api.Controllers
{
    [ApiController]
    [Validation]
    public class BaseController : Controller { }
}
