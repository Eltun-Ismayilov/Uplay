﻿using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Models.Pricings;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Pricings;
using Uplay.Domain.Enums;
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

        public async Task<PricingDetailsDto> Get(int pricingId, int date)
        {
            var pricing = await _pricingRepository.GetPricingById(pricingId, date);

            var dto = Mapper.Map<PricingDetailsDto>(pricing);

            if (pricing.Monthly == 12)
                dto.PriceDiscount = (pricing.Price - ((3 * pricing.Price * pricing.MonthDiscount) / 100))*3  + (9 * pricing.Price);

            return dto;
        }

        public async Task<PricingGetResponse> GetAll()
        {
            PricingGetResponse response = new();

            var pricingQuery = _pricingRepository.GetListByPricingTypeIdQuery();

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
