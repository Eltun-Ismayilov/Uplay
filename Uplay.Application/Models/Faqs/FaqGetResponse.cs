using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Faqs;

public class FaqGetResponse
{
    [JsonPropertyName("faq")] public FaqDto FaqDto { get; set; }
}