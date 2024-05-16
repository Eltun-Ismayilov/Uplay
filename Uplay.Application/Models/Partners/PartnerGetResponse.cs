using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Partners;

public class PartnerGetResponse
{
    [JsonPropertyName("partner")] public PartnerDto PartnerDto { get; set; }
}