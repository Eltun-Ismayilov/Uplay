using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.SocialLinks
{
    public class SaveSocialLinkRequest : IMapFrom<SocialLink>
    {
        public string Phone { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
        public string YoutubeUrl { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveSocialLinkRequest, SocialLink>();
        }
    }
}
