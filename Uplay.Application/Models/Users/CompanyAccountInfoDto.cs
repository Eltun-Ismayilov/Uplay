using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Application.Models.Companies;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Application.Models.Users;

public class CompanyAccountInfoDto: BaseDto, IMapFrom<User>
{
    public string Name { get; set; } 
    public string UserName { get; set; } 
    public string Surname { get; set; }
    public string Phone { get; set; }
    public CompanyDto CompanyInfo { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, CompanyAccountInfoDto>()
            .ForMember(e => e.CompanyInfo,
                d => d.MapFrom(p => p.Companies.FirstOrDefault()));
    }
}