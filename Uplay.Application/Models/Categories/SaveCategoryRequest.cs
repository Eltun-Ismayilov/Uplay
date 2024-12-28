using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Categories
{
    public class SaveCategoryRequest : IMapFrom<Category>
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveCategoryRequest, Category>();
        }
    }
}
