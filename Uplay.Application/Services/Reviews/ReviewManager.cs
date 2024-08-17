using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Mongo.FeedbackRetention;

namespace Uplay.Application.Services.Reviews;

public class ReviewManager: BaseManager, IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IFeedbackRetention _feedbackRetention;

    public ReviewManager(IMapper mapper, IReviewRepository reviewRepository, IFeedbackRetention feedbackRetention) : base(mapper)
    {
        this._reviewRepository = reviewRepository;
        _feedbackRetention = feedbackRetention;
    }

    public async Task<ActionResult<int>> Create(SaveReviewRequest command)
    {
        var mapping = Mapper.Map<Review>(command);
        var data = await _reviewRepository.InsertAsync(mapping);
        await _feedbackRetention.RecordReview(mapping);
        return data;
    }

    public async Task<ReviewGetAllResponse> GetAll(int id, PaginationFilter paginationFilter)
    {
        ReviewGetAllResponse response = new();

        var reviewQuery = _reviewRepository.GetReviewsByBranch(id);

        var list = await reviewQuery.PaginatedMappedListAsync<ReviewDto, Review>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.ReviewDtos = list;

        return response;
    }
}