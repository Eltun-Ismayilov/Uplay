using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Abouts
{
    public class SaveAboutRequest : IMapFrom<About>
    {
        public List<SaveAboutFileRequest> AboutFiles { get; set; } = null!;
        public List<SaveAboutTypeRequest> AboutTypes { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveAboutRequest, About>()
             .ForMember(dest => dest.AboutFiles, opt => opt.MapFrom(src => src.AboutFiles))
             .ForMember(dest => dest.AboutTypes, opt => opt.MapFrom(src => src.AboutTypes));
        }
    }
}
