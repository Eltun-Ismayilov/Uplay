using System.Text.Json.Serialization;
using Uplay.Application.Models.RatingBranchs;

namespace Uplay.Application.Models.RatingBranch
{
    public class RatingBranchGetResponse
    {
        [JsonPropertyName("ratingBranch")] 
        public RatingBranchDto RatingBranchDto { get; set; } = null!;

    }
}
