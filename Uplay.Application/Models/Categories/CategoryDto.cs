using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Categories
{
    public class CategoryDto : BaseDto, IMapFrom<Partner>
    {
        public string Name { get; set; } = string.Empty;
        public string File { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Partner, CategoryDto>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.Path));
        }
    }
}
