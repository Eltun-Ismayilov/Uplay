using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Companies
{
    public class SaveCompanyRequest : IMapFrom<Company>
    {
        public string BrandName { get; set; }=string.Empty; 
        public string CompanyName { get; set; } = string.Empty;
        public string Tin { get; set; } = string.Empty;
        public int BranchCount { get; set; } 
        public string City { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;
        public SaveUserRequest Onwer { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveCompanyRequest, Company>()
               .ForMember(entity => entity.Onwer, opt => opt.MapFrom(dto => dto.Onwer));
        }
    }
}
