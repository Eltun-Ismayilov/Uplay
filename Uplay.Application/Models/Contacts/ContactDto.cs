using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Contacts;

public class ContactDto: BaseDto, IMapFrom<Contact>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public bool IsARead { get; set; } = false;
}