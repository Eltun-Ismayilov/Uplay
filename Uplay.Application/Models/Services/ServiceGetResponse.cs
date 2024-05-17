using System.Text.Json.Serialization;
using Uplay.Application.Models.Partners;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Services
{
    public class ServiceGetResponse
    {
        [JsonPropertyName("service")] public ServiceDto ServiceDto { get; set; }
    }
}
