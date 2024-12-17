using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Helpers;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Feedbacks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Feedbacks;

public class FeedbackManager : BaseManager, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IPlaylistRepository _playlistRepository;
    private readonly IRepository<FeedbackType> _feedbackTypeRepository;

    public FeedbackManager(IMapper mapper,
        IFeedbackRepository feedbackRepository,
        IRepository<FeedbackType> feedbackTypeRepository,
        IReviewRepository reviewRepository,
        IRatingRepository ratingRepository,
        IPlaylistRepository playlistRepository) : base(mapper)
    {
        this._feedbackRepository = feedbackRepository;
        _feedbackTypeRepository = feedbackTypeRepository;
        _reviewRepository = reviewRepository;
        _ratingRepository = ratingRepository;
        _playlistRepository = playlistRepository;
    }

    public async Task<ActionResult<int>> Create(SaveFeedbackRequest command)
    {
        var mapping = Mapper.Map<Feedback>(command);
        var data = await _feedbackRepository.InsertAsync(mapping);
        return data;
    }

    public async Task<FeedbackGetAllResponse> GetAll(FeedbackFilter filter, PaginationFilter paginationFilter)
    {
        FeedbackGetAllResponse response = new();

        var predicate = PredicateBuilder.New<Feedback>();
        predicate = CreateFeedbackFilterQuery(predicate, filter);
        var feedbackQuery = _feedbackRepository.GetFeedbacksByBranch(predicate);

        var list = await feedbackQuery.PaginatedMappedListAsync<FeedbackDto, Feedback>(Mapper,
            paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.FeedbackDtos = list;

        return response;
    }

    public async Task<CommonStatistics> GetCommonStatistics(FilterQuery filter)
    {
        var response = new CommonStatistics();

        var fbPredicate = CreateFilterQuery(PredicateBuilder.New<Feedback>(), filter);
        var rPredicate = CreateFilterQuery(PredicateBuilder.New<Review>(), filter);
        var rbPredicate = CreateFilterQuery(PredicateBuilder.New<Uplay.Domain.Entities.Models.Landings.RatingBranch>(), filter);
        var plPredicate = CreateFilterQuery(PredicateBuilder.New<PlayList>(), filter);

        var feedbackQuery = _feedbackRepository.GetFeedbacksByBranch(fbPredicate);
        var reviewQuery = _reviewRepository.GetReviewsByBranch(rPredicate);
        var ratingQuery = _ratingRepository.GetRatingsByBranch(rbPredicate);
        var playlistQuery = _playlistRepository.GetPlaylistsByBranch(plPredicate);

        var feedbackTypeSummary = await _feedbackRepository.GetFeedbackSummaryByTypeAsync(feedbackQuery);

        response.FeedbackCount = feedbackQuery?.Count() ?? 0;
        response.ReviewCount = reviewQuery?.Count() ?? 0;
        response.RatingCount = ratingQuery?.Count() ?? 0;
        response.SongCount = playlistQuery?.Count() ?? 0;
        response.FeedbackTypeSummary = feedbackTypeSummary;

        return response;
    }

    #region Feedback type

    public async Task<ActionResult<int>> CreateFeedbackType(SaveFeedbackTypeRequest command)
    {
        var mapping = Mapper.Map<FeedbackType>(command);
        var data = await _feedbackTypeRepository.InsertAsync(mapping);
        return data;
    }

    public async Task<ActionResult<int>> DeleteFeedbackType(int feedbackTypeId)
    {
        var data = await _feedbackTypeRepository.GetByIdAsync(feedbackTypeId);
        if (data is null)
            throw new NotFoundException($"ID-si {feedbackTypeId} olan Feedback Type Yoxdur.");

        await _feedbackTypeRepository.DeleteAsync(data);
        return 204;
    }

    public async Task<ActionResult<int>> UpdateFeedbackType(int feedbackTypeId, SaveFeedbackTypeRequest request)
    {
        var data = await _feedbackTypeRepository.GetByIdAsync(feedbackTypeId);
        if (data is null)
            throw new NotFoundException($"ID-si {feedbackTypeId} olan Feedback Type Yoxdur.");

        var mapping = Mapper.Map(request, data);
        await _feedbackTypeRepository.UpdateAsync(mapping);
        return 204;
    }

    public async Task<FeedbackTypeGetAllReponse> GetAllFeedbackTypes(PaginationFilter paginationFilter)
    {
        FeedbackTypeGetAllReponse response = new();

        var feedbackQuery = _feedbackTypeRepository.GetAllQuery();

        var list = await feedbackQuery.PaginatedMappedListAsync<FeedbackTypeDto, FeedbackType>(Mapper,
            paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.FeedbackTypeDtos = list;

        return response;
    }

    #endregion

    private static Expression<Func<Feedback, bool>>? CreateFeedbackFilterQuery(
        Expression<Func<Feedback, bool>>? predicate,
        FeedbackFilter? filterQuery)
    {
        if (filterQuery is null || predicate is null) return predicate;

        predicate = filterQuery.StartDate is not null && filterQuery.EndDate is not null ? predicate.And(
                x =>
                    x.CreatedDate.Date >= filterQuery.StartDate.Value.Date &&
                    x.CreatedDate.Date <= filterQuery.EndDate.Value.Date)
            : filterQuery.StartDate is not null ? predicate.And(x =>
                x.CreatedDate == filterQuery.StartDate.Value)
            : predicate;

        predicate = filterQuery.FeedbackTypeId is not null
            ? predicate.And(x => x.FeedbackTypeId == filterQuery.FeedbackTypeId)
            : predicate;

        predicate = predicate.And(x => x.BranchId == filterQuery.BranchId);

        return predicate;
    }

    private static Expression<Func<T, bool>>? CreateFilterQuery<T>(
        Expression<Func<T, bool>>? predicate,
        FilterQuery? filterQuery) where T : IFilterable
    {
        if (filterQuery is null || predicate is null) return predicate;

        // Filter by date range
        if (filterQuery.StartDate.HasValue && filterQuery.EndDate.HasValue)
        {
            var startDate = filterQuery.StartDate.Value.Date;
            var endDate = filterQuery.EndDate.Value.Date;

            predicate = predicate.And(x =>
                x.CreatedDate.Date >= startDate && x.CreatedDate.Date <= endDate);
        }
        else if (filterQuery.StartDate.HasValue)
        {
            var startDate = filterQuery.StartDate.Value.Date;
            predicate = predicate.And(x =>
                x.CreatedDate.Date == startDate);
        }

        // Filter by branch ID
        predicate = predicate.And(x => x.BranchId == filterQuery.BranchId);

        return predicate;
    }

    public async Task<FeedbackTypeGetResponse> Get(int id)
    {
        FeedbackTypeGetResponse response = new();

        var feedbackType = await _feedbackTypeRepository.GetByIdAsync(id);
        var mapping = Mapper.Map<FeedbackTypeDto>(feedbackType);
        response.FeedbackTypeDto = mapping;

        return response;
    }
}