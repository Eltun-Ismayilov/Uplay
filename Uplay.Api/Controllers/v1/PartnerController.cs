using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Partners;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Partners;

namespace Uplay.Api.Controllers.v1;

public class PartnerController : BaseController
{
    private readonly IPartnerService _partnerService;

    public PartnerController(IPartnerService partnerService)
    {
        _partnerService = partnerService;
    }
    [AllowAnonymous]
    [HttpGet(ApiRoutes.PartnerRoute.GetAll)]
    public async Task<ActionResult<FaqGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _partnerService.GetAll(paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.PartnerRoute.Create)]
    public async Task<ActionResult<int>> Create([FromForm] SavePartnerRequest command)
    {
        var data = await _partnerService.Create(command);
        return Ok(data.Value);
    }
    [AllowAnonymous]
    [HttpGet(ApiRoutes.PartnerRoute.Get)]
    public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
    {
        var data = await _partnerService.Get(id);
        return Ok(data);
    }

    [HttpDelete(ApiRoutes.PartnerRoute.Delete)]
    public async Task<IActionResult> Delete([Required] int id)
    {
        await _partnerService.Delete(id);
        return NoContent();
    }

    [HttpPut(ApiRoutes.PartnerRoute.Update)]
    public async Task<IActionResult> Update(int id, [FromForm] SavePartnerRequest request)
    {
        await _partnerService.Update(id, request);
        return NoContent();
    }
}