using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Services
{
    public class ServiceDto : BaseDto, IMapFrom<Service>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ServiceTypeDto ServiceTypes { get; set; } = null!;
        public string File { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.Path))
                .ForMember(dest => dest.ServiceTypes, opt => opt.MapFrom(src => src.ServiceType));
        }
    }
}
