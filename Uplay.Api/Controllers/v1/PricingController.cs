using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;
using Uplay.Application.Models.Pricings;
using Uplay.Application.Models.Services;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Partners;
using Uplay.Application.Services.Pricings;
using Uplay.Application.Services.Services;
using Uplay.Domain.Enums;

namespace Uplay.Api.Controllers.v1
{
    public class PricingController : BaseController
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }



        [AllowAnonymous]
        [HttpGet(ApiRoutes.PricingRoute.GetAll)]
        public async Task<ActionResult<PricingGetResponse>> GetAll()
        {
            var data = await _pricingService.GetAll();
            return Ok(data);
        }

        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.PricingRoute.Get)]
        //public async Task<ActionResult<PricingDetailsDto>> Get(int pricingId, int date)
        //{
        //    var data = await _pricingService.Get(pricingId, date);
        //    return Ok(data);
        //}


        //[HttpPut(ApiRoutes.PricingRoute.Update)]
        //public async Task<IActionResult> Update(int id, [FromBody] SavePricingRequest request)
        //{
        //    await _pricingService.Update(id, request);
        //    return NoContent();
        //}

        //[HttpDelete(ApiRoutes.PricingRoute.Delete)]
        //public async Task<IActionResult> Delete([Required] int id)
        //{
        //    await _pricingService.Delete(id);
        //    return NoContent();
        //}

        //[HttpPost(ApiRoutes.PricingRoute.Create)]
        //public async Task<ActionResult<int>> Create([FromBody] SavePricingRequest command)
        //{
        //    var data = await _pricingService.Create(command);
        //    return Ok(data.Value);
        //}
    }
}
