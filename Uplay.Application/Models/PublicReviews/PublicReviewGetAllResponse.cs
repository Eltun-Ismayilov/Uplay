using System.Text.Json.Serialization;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.PublicReviews
{
    public class PublicReviewGetAllResponse
    {
        [JsonPropertyName("publicReviews")] public PaginatedMappedList<PublicReviewDto, PublicReview> PublicReviewDtos { get; set; }
    }
}
