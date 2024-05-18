using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Abouts
{
    public class AboutTypeDto : BaseDto, IMapFrom<AboutType>
    {
        public string Name { get; set; }=string.Empty;  
        public string Description { get; set; } = string.Empty;
        public string File { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AboutType, AboutTypeDto>()
                        .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.Path));
        }
    }
}
