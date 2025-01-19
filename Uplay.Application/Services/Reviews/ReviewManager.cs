using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Helpers;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Reviews;

public class ReviewManager : BaseManager, IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IBranchRepository _branchRepository;

    public ReviewManager(IMapper mapper, IReviewRepository reviewRepository, IBranchRepository branchRepository) : base(mapper)
    {
        this._reviewRepository = reviewRepository;
        _branchRepository = branchRepository;
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

    public async Task<int> Update(int id, SaveReviewRequest request)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        if (review is null)
            throw new NotFoundException($"ID-si {id} olan Review Yoxdur.");

        var branch = await _branchRepository.GetByIdAsync(request.BranchId);

        if (branch is null)
            throw new NotFoundException($"ID-si {request.BranchId} olan Branch Yoxdur.");

        var mapping = Mapper.Map(request, review);

        await _reviewRepository.UpdateAsync(mapping, true);

        return 204;
    }
}