using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Feedbacks;

public class FeedbackManager: BaseManager, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackManager(IMapper mapper, IFeedbackRepository feedbackRepository) : base(mapper)
    {
        this._feedbackRepository = feedbackRepository;
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
        
        var list = await feedbackQuery.PaginatedMappedListAsync<FeedbackDto, Feedback>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.FeedbackDtos = list;

        return response;
    }
}