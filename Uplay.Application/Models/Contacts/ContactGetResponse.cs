using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Contacts;

public class ContactGetResponse
{
    [JsonPropertyName("contacts")] public ContactDto ContactDto { get; set; }
}