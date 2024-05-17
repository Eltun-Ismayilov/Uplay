using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Faqs;

public class FaqManager : BaseManager, IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqManager(IFaqRepository faqRepository,IMapper mapper) : base(mapper)
        {
            _faqRepository = faqRepository;
        }
        public async Task<ActionResult<int>> Create(SaveFaqRequest command)
        {
            var mapping = Mapper.Map<Faq>(command);
            var data = await _faqRepository.InsertAsync(mapping);
            return data;
        }

        public async Task<int> Delete(int faqId)
        {
            var data = await _faqRepository.GetByIdAsync(faqId);
            if (data is null)
                throw new NotFoundException($"ID-si {faqId} olan Faq Yoxdur.");

            await _faqRepository.DeleteAsync(data);
            return 204;
        }

        public async Task<FaqGetAllResponse> GetAll(PaginationFilter paginationFilter)
        {
            FaqGetAllResponse response = new();

            var faqQuery = _faqRepository.GetListQuery();

            var list = await faqQuery.PaginatedMappedListAsync<FaqDto, Faq>(Mapper, paginationFilter.PageNumber, paginationFilter.PageSize);
            response.FaqDtos = list;

            return response;
        }
        
        public async Task<FaqGetResponse> Get(int id)
        {
            FaqGetResponse response = new();

            var faqQuery = await _faqRepository.GetByIdAsync(id);
            var mapping = Mapper.Map<FaqDto>(faqQuery);
            response.FaqDto = mapping;

            return response;
        }

        public async Task<int> Update(int id, SaveFaqRequest command)
        {
            var data = await _faqRepository.GetByIdAsync(id);
            if (data is null) 
                throw new NotFoundException($"ID-si {id} olan Faq Yoxdur.");

            var mapping = Mapper.Map(command, data);
            await _faqRepository.UpdateAsync(mapping, true);
            return 204;
        }
    }