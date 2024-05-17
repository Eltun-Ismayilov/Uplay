using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Services
{
    public class SaveServiceRequest:IMapFrom<Service>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ServiceTypeId { get; set; }
        public IFormFile File { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveServiceRequest, Service>();
        }
    }
}
