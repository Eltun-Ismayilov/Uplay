using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Feedbacks;

public class FeedbackGetAllResponse
{
    [JsonPropertyName("feedbacks")] public PaginatedMappedList<FeedbackDto, Feedback> FeedbackDtos { get; set; }
}