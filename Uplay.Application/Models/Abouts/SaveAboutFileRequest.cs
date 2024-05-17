using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Abouts
{
    public class SaveAboutFileRequest : IMapFrom<AboutFile>
    {
        public IFormFile File { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveAboutFileRequest, AboutFile>();
        }
    }
}
