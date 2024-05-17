using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Services;
using Uplay.Application.Models.Services;

namespace Uplay.Api.Controllers.v1
{

    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet(ApiRoutes.ServiceRoute.GetAll)]
        public async Task<ActionResult<ServiceGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var data = await _serviceService.GetAll(paginationFilter);
            return Ok(data);
        }

        [HttpPost(ApiRoutes.ServiceRoute.Create)]
        public async Task<ActionResult<int>> Create([FromForm] SaveServiceRequest command)
        {
            var data = await _serviceService.Create(command);
            return Ok(data.Value);
        }
        [HttpGet(ApiRoutes.ServiceRoute.Get)]
        public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
        {
            var data = await _serviceService.Get(id);
            return Ok(data);
        }

        [HttpDelete(ApiRoutes.ServiceRoute.Delete)]
        public async Task<IActionResult> Delete([Required] int id)
        {
            await _serviceService.Delete(id);
            return NoContent();
        }

        [HttpPut(ApiRoutes.ServiceRoute.Update)]
        public async Task<IActionResult> Update(int faqId, [FromForm] SaveServiceRequest updateServiceDto)
        {
            await _serviceService.Update(faqId, updateServiceDto);
            return NoContent();
        }
    }
}
