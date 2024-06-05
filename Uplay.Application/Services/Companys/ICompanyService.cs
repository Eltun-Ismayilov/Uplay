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
        Task<ActionResult<int>> Create(SaveCompanyRequest command);
    }
}
