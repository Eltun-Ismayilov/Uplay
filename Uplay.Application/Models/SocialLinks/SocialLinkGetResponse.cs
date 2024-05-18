using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Uplay.Application.Models.Services;

namespace Uplay.Application.Models.SocialLinks
{
    public class SocialLinkGetResponse
    {
        [JsonPropertyName("socialLink")] public SocialLinkDto SocialLinkDto { get; set; }

    }
}
