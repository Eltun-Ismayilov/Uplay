using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Reviews;

public class ReviewManager: BaseManager, IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewManager(IMapper mapper, IReviewRepository reviewRepository) : base(mapper)
    {
        this._reviewRepository = reviewRepository;
    }

    public async Task<ActionResult<int>> Create(SaveReviewRequest command)
    {

        var mapping = Mapper.Map<Review>(command);

        var data = await _reviewRepository.InsertAsync(mapping);

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