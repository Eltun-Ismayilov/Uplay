using System.Text.Json.Serialization;

namespace Uplay.Application.Models.PublicReviews
{
    public class PublicReviewGetResponse
    {
        [JsonPropertyName("publicReview")] public PublicReviewDto PublicReviewDto { get; set; }

    }
}
