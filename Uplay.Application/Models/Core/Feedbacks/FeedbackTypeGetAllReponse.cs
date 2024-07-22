using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Application.Models.Core.Feedbacks;

public class FeedbackTypeGetAllReponse
{
    [JsonPropertyName("feedbacks")] public PaginatedMappedList<FeedbackTypeDto, FeedbackType> FeedbackTypeDtos { get; set; }
}