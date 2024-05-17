using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Services
{
    public class ServiceTypeDto : BaseDto, IMapFrom<ServiceType>
    {
        public string Name { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ServiceType, ServiceTypeDto>();
        }
    }
}
