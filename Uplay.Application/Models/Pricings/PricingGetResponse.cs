using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Pricings
{
    public class PricingGetResponse
    {
        [JsonPropertyName("pricings")] public ICollection<PricingDto> PricingDtos { get; set; } = null!;
    }
}
