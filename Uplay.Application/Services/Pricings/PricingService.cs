using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Models.Pricings;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Pricings;
using Uplay.Domain.Enum;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Pricings
{
    public class PricingService : BaseManager, IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IPricingSectionRepository _pricingSectionRepository;
        public PricingService(
            IPricingRepository pricingRepository,
            IMapper mapper,
            IPricingSectionRepository pricingSectionRepository) : base(mapper)
        {
            _pricingRepository = pricingRepository;
            _pricingSectionRepository = pricingSectionRepository;
        }

        public async Task<ActionResult<int>> Create(SavePricingRequest command)
        {
            var mapping = Mapper.Map<Pricing>(command);

            var data = await _pricingRepository.InsertAsync(mapping);
            return data;
        }

        public async Task<int> Delete(int id)
        {
            var data = await _pricingRepository.GetByIdAsync(id);

            if (data is null)
                throw new NotFoundException($"ID-si {id} olan Pricing Yoxdur.");

            await _pricingRepository.DeleteAsync(data);

            return 204;
        }

        public async Task<PricingGetResponse> GetAll(PricingTypeEnum pricingTypeId)
        {
            PricingGetResponse response = new();

            var pricingQuery = _pricingRepository.GetListByPricingTypeIdQuery((int)pricingTypeId);

            var list = Mapper.Map<List<PricingDto>>(pricingQuery);

            response.PricingDtos = list;

            return response;
        }

        public async Task<int> Update(int id, SavePricingRequest command)
        {
            var data = await _pricingRepository.GetByPricingId(id);

            if (data is null)
                throw new NotFoundException($"ID-si {id} olan Pricing Yoxdur.");

            foreach (var pricingSection in data.PricingSections)
                await _pricingSectionRepository.DeleteAsync(pricingSection);

            var mapping = Mapper.Map(command, data);

            await _pricingRepository.UpdateAsync(mapping);

            return 204;
        }
    }
}
