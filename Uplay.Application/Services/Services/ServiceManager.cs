using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;
using Uplay.Application.Models.Services;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Enum;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Services
{
    public class ServiceManager : BaseManager, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(
            IServiceRepository serviceRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(mapper, httpContextAccessor)
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

            var fileUrl = HttpContextAccessor.GeneratePhotoUrl(service.FileId);

            mapping.Url = fileUrl;

            response.ServiceDto = mapping;

            return response;
        }

        public async Task<ServiceGetAllResponse> GetAll(ServiceTypeEnum serviceTypeId, PaginationFilter paginationFilter)
        {
            ServiceGetAllResponse response = new();

            if ((int)serviceTypeId != 1 && (int)serviceTypeId != 2)
                throw new NotFoundException("ServiceTypeId not found");

            var services = _serviceRepository.GetListByServiceTypeIdQuery(serviceTypeId);

            var list = await services.PaginatedMappedListAsync<ServiceDto, Service>(Mapper, paginationFilter.PageNumber,
                paginationFilter.PageSize);

            foreach (var service in services)
            {
                var fileUrl = HttpContextAccessor.GeneratePhotoUrl(service.FileId);

                var datas = list.Items.FirstOrDefault(x => x.Url == null);

                datas.Url = fileUrl;
            }

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
