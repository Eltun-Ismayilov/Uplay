using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Companies;
using Uplay.Application.Services.Companys;

namespace Uplay.Api.Controllers.v1
{

    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.CompanyRoute.Create)]
        public async Task<ActionResult<int>> Create([FromForm] SaveCompanyRequest command)
        {
            var data = await _companyService.Create(command);
            return Ok(data.Value);
        }
    }
}
