using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models;
using Uplay.Application.Models.SocialLinks;

namespace Uplay.Application.Services.SocialLinks
{
    public interface ISocialLinkService: IBaseService
    {
        Task<ActionResult<int>> Create(SaveSocialLinkRequest command);
        Task<SocialLinkGetResponse> Get();
        Task<int> Update(int id, SaveSocialLinkRequest command);
    }
}
