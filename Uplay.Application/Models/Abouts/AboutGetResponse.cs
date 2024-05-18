using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Abouts
{
    public class AboutGetResponse
    {
        [JsonPropertyName("about")] public AboutDto AboutDto { get; set; }

    }
}
