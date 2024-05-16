using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Services.Faqs;

namespace Uplay.Api.Controllers.v1;

public class FaqController : BaseController
    {

        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }
        [HttpGet(ApiRoutes.FaqRoute.GetAll)]
        public async Task<ActionResult<FaqGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var data = await _faqService.GetAll(paginationFilter);
            return Ok(data);
        }

        [HttpPost(ApiRoutes.FaqRoute.Create)]
        public async Task<ActionResult<int>> Create([FromBody] SaveFaqRequest command)
        {
            var data = await _faqService.Create(command);
            return Ok(data.Value);
        }
        [HttpGet(ApiRoutes.FaqRoute.Get)]
        public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
        {
            var data = await _faqService.Get(id);
            return Ok(data);
        }

        [HttpDelete(ApiRoutes.FaqRoute.Delete)]
        public async Task<IActionResult> Delete([Required] int id)
        {
            await _faqService.Delete(id);
            return NoContent();
        }

        [HttpPut(ApiRoutes.FaqRoute.Update)]
        public async Task<IActionResult> Update( int faqId, [FromBody] SaveFaqRequest updateFaqDto)
        {
            await _faqService.Update(faqId, updateFaqDto);
            return NoContent();
        }
    }