﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Services;
using Uplay.Application.Models.Services;
using Uplay.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Uplay.Api.Attributes;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1
{

    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.ServiceRoute.GetAll)]
        public async Task<ActionResult<ServiceGetAllResponse>> GetAll([Required] ServiceTypeEnum serviceTypeId, [FromQuery] PaginationFilter paginationFilter)
        {
            var data = await _serviceService.GetAll(serviceTypeId, paginationFilter);
            return Ok(data);
        }

        [CheckPermission((int)ClaimEnum.Service_Post)]
        [HttpPost(ApiRoutes.ServiceRoute.Create)]
        public async Task<ActionResult<int>> Create([FromForm] SaveServiceRequest command)
        {
            var data = await _serviceService.Create(command);
            return Ok(data.Value);
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.ServiceRoute.Get)]
        public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
        {
            var data = await _serviceService.Get(id);
            return Ok(data);
        }

        [CheckPermission((int)ClaimEnum.Service_Delete)]
        [HttpDelete(ApiRoutes.ServiceRoute.Delete)]
        public async Task<IActionResult> Delete([Required] int id)
        {
            await _serviceService.Delete(id);
            return NoContent();
        }

        [CheckPermission((int)ClaimEnum.Service_Put)]
        [HttpPut(ApiRoutes.ServiceRoute.Update)]
        public async Task<IActionResult> Update(int id, [FromForm] SaveServiceRequest updateServiceDto)
        {
            await _serviceService.Update(id, updateServiceDto);
            return NoContent();
        }
    }
}
