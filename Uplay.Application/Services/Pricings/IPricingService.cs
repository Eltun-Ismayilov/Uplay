using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;
using Uplay.Application.Models.Pricings;
using Uplay.Application.Models.PublicReviews;
using Uplay.Domain.Enum;

namespace Uplay.Application.Services.Pricings
{
    public interface IPricingService:IBaseService
    {
        Task<ActionResult<int>> Create(SavePricingRequest command);
        Task<PricingGetResponse> GetAll(PricingTypeEnum pricingTypeId);
        Task<int> Update(int id, SavePricingRequest command);
        Task<int> Delete(int id);

    }
}
