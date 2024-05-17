using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Partners;

public class PartnerDto : BaseDto, IMapFrom<Partner>
{
    public string Name { get; set; }
    public string File { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Partner, PartnerDto>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.Path));
    }
}