using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Helpers;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Reviews;

public class ReviewManager : BaseManager, IReviewService
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

    public async Task<ReviewGetAllResponse> GetAll(ReviewFilter filter, PaginationFilter paginationFilter)
    {
        ReviewGetAllResponse response = new();
        var predicate = PredicateBuilder.New<Review>();
        predicate = CreateReviewFilterQuery(predicate, filter);
        var reviewQuery = _reviewRepository.GetReviewsByBranch(predicate);

        var list = await reviewQuery.PaginatedMappedListAsync<ReviewDto, Review>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.ReviewDtos = list;

        return response;
    }

    public static Expression<Func<Review, bool>>? CreateReviewFilterQuery(
        Expression<Func<Review, bool>>? predicate,
        ReviewFilter? filterQuery)
    {
        if (filterQuery is null || predicate is null) return predicate;

        predicate = filterQuery.StartDate is not null && filterQuery.EndDate is not null ? predicate.And(
                x =>
                    x.CreatedDate.Date >= filterQuery.StartDate.Value.Date &&
                    x.CreatedDate.Date <= filterQuery.EndDate.Value.Date)
            : filterQuery.StartDate is not null ? predicate.And(x =>
                x.CreatedDate == filterQuery.StartDate.Value)
            : predicate;

        predicate = predicate.And(x => x.BranchId == filterQuery.BranchId);

        return predicate;
    }
}