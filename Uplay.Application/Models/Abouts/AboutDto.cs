using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Abouts
{
    public class AboutDto : BaseDto, IMapFrom<About>
    {
        public AboutDto()
        {
            AboutFiles = new List<AboutFileDto>();
            AboutTypes = new List<AboutTypeDto>();
        }
        public ICollection<AboutFileDto> AboutFiles { get; set; }
        public ICollection<AboutTypeDto> AboutTypes { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<About, AboutDto>()
                .ForMember(dest => dest.AboutFiles, opt => opt.MapFrom(src => src.AboutFiles))
                .ForMember(dest => dest.AboutTypes, opt => opt.MapFrom(src => src.AboutTypes));

        }
    }
}
