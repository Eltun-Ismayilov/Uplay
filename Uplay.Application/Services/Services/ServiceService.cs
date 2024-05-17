using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;
using Uplay.Application.Models.Services;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Services
{
    public class ServiceService : BaseManager, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(
            IServiceRepository serviceRepository, 
            IMapper mapper) : base(mapper)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ActionResult<int>> Create(SaveServiceRequest command)
        {
            var mapping = Mapper.Map<Service>(command);
            var data = await _serviceRepository.InsertAsync(mapping);
            return data;
        }

        public async Task<int> Delete(int id)
        {
            var data = await _serviceRepository.GetByIdAsync(id);
            if (data is null)
                throw new NotFoundException($"ID-si {id} olan Service Yoxdur.");

            await _serviceRepository.DeleteAsync(data);
            return 204;
        }

        public async Task<ServiceGetResponse> Get(int id)
        {
            ServiceGetResponse response = new();

            var service = await _serviceRepository.GetServiceByIdAsync(id)
                          ?? throw new NotFoundException("Service not found");

            var mapping = Mapper.Map<ServiceDto>(service);
            response.ServiceDto = mapping;

            return response;
        }

        public async Task<ServiceGetAllResponse> GetAll(PaginationFilter paginationFilter)
        {
            ServiceGetAllResponse response = new();

            var services = _serviceRepository.GetListQuery();

            var list = await services.PaginatedMappedListAsync<ServiceDto, Service>(Mapper, paginationFilter.PageNumber,
                paginationFilter.PageSize);
            response.ServiceDtos = list;

            return response;
        }

        public async Task<int> Update(int id, SaveServiceRequest command)
        {
            var data = await _serviceRepository.GetByIdAsync(id);
            if (data is null)
                throw new NotFoundException($"ID-si {id} olan Service Yoxdur.");

            var mapping = Mapper.Map(command, data);
            await _serviceRepository.UpdateAsync(mapping);
            return 204;
        }
    }
}
