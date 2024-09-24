using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Companies;
using Uplay.Application.Models.Faqs;

namespace Uplay.Application.Services.Companys
{
    public interface ICompanyService : IBaseService
    {
        Task<ActionResult<int>> CreateCorporateAsync(SaveCompanyRequest command);
        Task<ActionResult<int>> CreatePersonalAsync(SavePersonalRequest command);
        Task<ActionResult<int>> GetOperationId(Guid operationId);
        Task<ActionResult<CompanyDetailsDto>> GetCompany(int companyId);
    }
}
