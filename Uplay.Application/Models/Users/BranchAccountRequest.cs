using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Application.Models.Users;

public class BranchAccountRequest: IMapFrom<User>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public string City { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BranchAccountRequest, User>();
    }
}

