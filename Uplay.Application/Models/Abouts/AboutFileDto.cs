using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Abouts
{
    public class AboutFileDto:BaseDto, IMapFrom<AboutFile>
    {
        public string File { get; set; }=string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AboutFile, AboutFileDto>()
                        .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.Path));
        }
    }
}
