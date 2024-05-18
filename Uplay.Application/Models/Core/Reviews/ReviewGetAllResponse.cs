using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Core.Reviews;

public class ReviewGetAllResponse
{
    [JsonPropertyName("feedbacks")] public PaginatedMappedList<ReviewDto, Review> ReviewDtos { get; set; }
}