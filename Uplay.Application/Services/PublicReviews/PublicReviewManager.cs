using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.PublicReviews;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.PublicReviews
{
    public class PublicReviewManager : BaseManager, IPublicReviewService
    {
        private readonly IPublicReviewRepository _publicReviewRepository;

        public PublicReviewManager(
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

            var publicReview = await _publicReviewRepository.GetPublicReviewByIdAsync(id)
                          ?? throw new NotFoundException("PublicReview not found");

            var mapping = Mapper.Map<PublicReviewDto>(publicReview);

            var fileUrl = HttpContextAccessor.GeneratePhotoUrl(publicReview.FileId);

            mapping.Url = fileUrl;

            response.PublicReviewDto = mapping;

            return response;
        }

        public async Task<PublicReviewGetAllResponse> GetAll(PaginationFilter paginationFilter)
        {
            PublicReviewGetAllResponse response = new();

            var publicReviewQuery = _publicReviewRepository.GetListQuery();

            var list = await publicReviewQuery.PaginatedMappedListAsync<PublicReviewDto, PublicReview>(Mapper, paginationFilter.PageNumber,
                paginationFilter.PageSize);


            foreach (var publicReview in publicReviewQuery)
            {
                var fileUrl = HttpContextAccessor.GeneratePhotoUrl(publicReview.FileId);

                var datas = list.Items.FirstOrDefault(x => x.Url == null);

                datas.Url = fileUrl;
            }

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
