﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models.Companies;
using Uplay.Application.Services.Companys;

namespace Uplay.Api.Controllers.v1
{

    [AllowAnonymous]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost(ApiRoutes.CompanyRoute.CreateCorporate)]
        public async Task<ActionResult<int>> CreateCorporate([FromForm] SaveCompanyRequest command)
        {
            var data = await _companyService.CreateCorporateAsync(command);
            return Ok(data.Value);
        }

        [HttpPost(ApiRoutes.CompanyRoute.CreatePersonal)]
        public async Task<ActionResult<int>> CreatePersonal([FromForm] SavePersonalRequest command)
        {
            var data = await _companyService.CreatePersonalAsync(command);
            return Ok(data.Value);
        }
        
        [HttpGet(ApiRoutes.CompanyRoute.Get)]
        public async Task<ActionResult<CompanyDetailsDto>> GetCompany(int companyId)
        {
            var data = await _companyService.GetCompany(companyId);
            return Ok(data.Value);
        }
    }
}
