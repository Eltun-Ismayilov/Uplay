using System.Text.Json.Serialization;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Partners;

public class PartnerGetAllResponse
{
    [JsonPropertyName("partners")] public PaginatedMappedList<PartnerDto, Partner> PartnerDtos { get; set; }
}