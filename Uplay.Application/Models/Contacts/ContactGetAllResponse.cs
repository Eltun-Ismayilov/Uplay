using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Contacts;

public class ContactGetAllResponse
{
    [JsonPropertyName("contacts")] public PaginatedMappedList<ContactDto, Contact> ContactDtos { get; set; }
}