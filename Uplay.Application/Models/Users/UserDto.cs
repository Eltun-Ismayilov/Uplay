using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Application.Models.Core.Branches;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Application.Models.Users;

public class UserDto: BaseDto, IMapFrom<User>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string BrandName { get; set; }
    public BranchDto BusinessDetails { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>()
            .ForMember(e => e.BusinessDetails,
                d => d.MapFrom(p => p.Branches.FirstOrDefault()));
    }
}                     