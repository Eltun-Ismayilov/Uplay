using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Helpers;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Mongo.FeedbackRetention;

namespace Uplay.Application.Services.Feedbacks;

public class FeedbackManager : BaseManager, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IRepository<FeedbackType> _feedbackTypeRepository;
    private readonly IFeedbackRetention _feedbackRetention;

    public FeedbackManager(IMapper mapper,
        IFeedbackRepository feedbackRepository,
        IRepository<FeedbackType> feedbackTypeRepository, IFeedbackRetention feedbackRetention) : base(mapper)
    {
        this._feedbackRepository = feedbackRepository;
        _feedbackTypeRepository = feedbackTypeRepository;
        _feedbackRetention = feedbackRetention;
    }

    public async Task<ActionResult<int>> Create(SaveFeedbackRequest command)
    {
        var mapping = Mapper.Map<Feedback>(command);
        var data = await _feedbackRepository.InsertAsync(mapping);
        await _feedbackRetention.RecordFeedback(mapping);
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
                    x.CreatedDate.Date >= filterQuery.StartDate.Value.Date && x.CreatedDate.Date <= filterQuery.EndDate.Value.Date)
            : filterQuery.StartDate is not null ? predicate.And(x =>
                x.CreatedDate == filterQuery.StartDate.Value)
            : predicate;

        predicate = filterQuery.FeedbackTypeId is not null
            ? predicate.And(x => x.FeedbackTypeId == filterQuery.FeedbackTypeId)
            : predicate;

        predicate = predicate.And(x => x.BranchId == filterQuery.BranchId);

        return predicate;
    }
}