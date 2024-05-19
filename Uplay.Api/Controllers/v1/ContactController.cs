using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Contacts;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Partners;
using Uplay.Application.Services.Contacts;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Partners;

namespace Uplay.Api.Controllers.v1;

public class ContactController : BaseController
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet(ApiRoutes.ContactRoute.GetAll)]
    public async Task<ActionResult<FaqGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _contactService.GetAll(paginationFilter);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.ContactRoute.Create)]
    public async Task<ActionResult<int>> Create([FromBody] SaveContactRequest command)
    {
        var data = await _contactService.Create(command);
        return Ok(data.Value);
    }

    [HttpGet(ApiRoutes.ContactRoute.Get)]
    public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
    {
        var data = await _contactService.Get(id);
        return Ok(data);
    }
}