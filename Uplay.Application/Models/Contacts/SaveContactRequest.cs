using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Contacts;

public class SaveContactRequest: IMapFrom<Contact>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SaveContactRequest, Contact>();
    }
}