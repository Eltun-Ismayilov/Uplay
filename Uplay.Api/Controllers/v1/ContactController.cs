using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Attributes;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Contacts;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Partners;
using Uplay.Application.Services.Contacts;
using Uplay.Application.Services.Faqs;
using Uplay.Application.Services.Partners;
using Uplay.Domain.Enums.User;

namespace Uplay.Api.Controllers.v1;

public class ContactController : BaseController
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [CheckPermission((int)ClaimEnum.Contact_Get)]
    [HttpGet(ApiRoutes.ContactRoute.GetAll)]
    public async Task<ActionResult<FaqGetAllResponse>> GetAll([FromQuery] PaginationFilter paginationFilter)
    {
        var data = await _contactService.GetAll(paginationFilter);
        return Ok(data);
    }
    [AllowAnonymous]
    [HttpPost(ApiRoutes.ContactRoute.Create)]
    public async Task<ActionResult<int>> Create([FromBody] SaveContactRequest command)
    {
        var data = await _contactService.Create(command);
        return Ok(data.Value);
    }

    [CheckPermission((int)ClaimEnum.Contact_Details)]
    [HttpGet(ApiRoutes.ContactRoute.Get)]
    public async Task<ActionResult<FaqGetResponse>> Get([Required] int id)
    {
        var data = await _contactService.Get(id);
        return Ok(data);
    }
}