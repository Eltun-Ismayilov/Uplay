using AutoMapper;
using Microsoft.AspNetCore.Http;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.PublicReviews
{
    public class SavePublicReviewRequest : IMapFrom<PublicReview>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SavePublicReviewRequest, PublicReview>();
        }
    }
}
