using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Core.Feedbacks
{
    public class FeedbackTypeGetResponse
    {
        [JsonPropertyName("FeedbackTypeDto")] public FeedbackTypeDto FeedbackTypeDto { get; set; }
    }
}
