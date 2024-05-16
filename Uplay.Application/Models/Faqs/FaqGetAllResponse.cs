using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Faqs;

public class FaqGetAllResponse
{
    [JsonPropertyName("faqs")] public PaginatedMappedList<FaqDto, Faq> FaqDtos { get; set; }
}