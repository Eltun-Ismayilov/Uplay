using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Companies
{
    public class SavePersonalRequest : IMapFrom<Company>
    {
        public string BrandName { get; set; } = string.Empty;
        public string Tin { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = null!;
        public string City { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;
        public SaveUserRequest Onwer { get; set; } = null!;
        public string QrCodeLink { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SavePersonalRequest, Company>()
               .ForMember(entity => entity.Onwer, opt => opt.MapFrom(dto => dto.Onwer))
               .ForMember(entity => entity.BranchCount, opt => opt.MapFrom(dto => 1))
               .ForMember(entity => entity.CompanyName, opt => opt.MapFrom(dto => dto.BrandName))
               .ForMember(entity => entity.Aktiv, opt => opt.MapFrom(dto => true));
        }
    }
}
