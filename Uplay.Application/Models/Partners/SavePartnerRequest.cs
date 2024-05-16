using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Partners;

public class SavePartnerRequest: IMapFrom<Partner>
{
    public string Name { get; set; }
    public IFormFile File { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SavePartnerRequest, Partner>();
    }
}