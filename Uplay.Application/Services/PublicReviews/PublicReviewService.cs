using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.PublicReviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.PublicReviews
{
    public class PublicReviewService : BaseManager, IPublicReviewService
    {
        private readonly IPublicReviewRepository _publicReviewRepository;

        public PublicReviewService(
            IPublicReviewRepository publicReviewRepository, 
            IMapper mapper) : base(mapper)
        {
            _publicReviewRepository = publicReviewRepository;
        }

        public async Task<ActionResult<int>> Create(SavePublicReviewRequest command)
        {
            var mapping = Mapper.Map<PublicReview>(command);
            var data = await _publicReviewRepository.InsertAsync(mapping);
            return data;
        }

        public async Task<int> Delete(int id)
        {
            var data = await _publicReviewRepository.GetByIdAsync(id);
            if (data is null)
                throw new NotFoundException($"ID-si {id} olan PublicReview Yoxdur.");

            await _publicReviewRepository.DeleteAsync(data);
            return 204;
        }

        public async Task<PublicReviewGetResponse> Get(int id)
        {
            PublicReviewGetResponse response = new();

            var partner = await _publicReviewRepository.GetPublicReviewByIdAsync(id)
                          ?? throw new NotFoundException("PublicReview not found");

            var mapping = Mapper.Map<PublicReviewDto>(partner);
            response.PublicReviewDto = mapping;

            return response;
        }

        public async Task<PublicReviewGetAllResponse> GetAll(PaginationFilter paginationFilter)
        {
            PublicReviewGetAllResponse response = new();

            var publicReviewQuery = _publicReviewRepository.GetListQuery();

            var list = await publicReviewQuery.PaginatedMappedListAsync<PublicReviewDto, PublicReview>(Mapper, paginationFilter.PageNumber,
                paginationFilter.PageSize);
            response.PublicReviewDtos = list;

            return response;
        }

        public async Task<int> Update(int id, SavePublicReviewRequest command)
        {
            var data = await _publicReviewRepository.GetByIdAsync(id);
            if (data is null)
                throw new NotFoundException($"ID-si {id} olan PublicReview Yoxdur.");

            var mapping = Mapper.Map(command, data);
            await _publicReviewRepository.UpdateAsync(mapping);
            return 204;
        }
    }
}
