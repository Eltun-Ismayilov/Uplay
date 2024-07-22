using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Feedbacks;

public class FeedbackManager : BaseManager, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IRepository<FeedbackType> _feedbackTypeRepository;

    public FeedbackManager(IMapper mapper,
        IFeedbackRepository feedbackRepository,
        IRepository<FeedbackType> feedbackTypeRepository) : base(mapper)
    {
        this._feedbackRepository = feedbackRepository;
        _feedbackTypeRepository = feedbackTypeRepository;
    }

    public async Task<ActionResult<int>> Create(SaveFeedbackRequest command)
    {
        var mapping = Mapper.Map<Feedback>(command);
        var data = await _feedbackRepository.InsertAsync(mapping);
        return data;
    }

    public async Task<FeedbackGetAllResponse> GetAll(int id, PaginationFilter paginationFilter)
    {
        FeedbackGetAllResponse response = new();

        var feedbackQuery = _feedbackRepository.GetFeedbacksByBranch(id);

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
}