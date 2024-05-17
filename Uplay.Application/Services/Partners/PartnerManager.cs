using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Partners;

public class PartnerManager : BaseManager, IPartnerService
{
    private readonly IPartnerRepository _partnerRepository;

    public PartnerManager(IPartnerRepository partnerRepository, IMapper mapper) : base(mapper)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<ActionResult<int>> Create(SavePartnerRequest command)
    {
        var mapping = Mapper.Map<Partner>(command);
        var data = await _partnerRepository.InsertAsync(mapping);
        return data;
    }

    public async Task<int> Delete(int id)
    {
        var data = await _partnerRepository.GetByIdAsync(id);
        if (data is null)
            throw new NotFoundException($"ID-si {id} olan Partner Yoxdur.");

        await _partnerRepository.DeleteAsync(data);
        return 204;
    }

    public async Task<PartnerGetAllResponse> GetAll(PaginationFilter paginationFilter)
    {
        PartnerGetAllResponse response = new();

        var partnerQuery = _partnerRepository.GetListQuery();

        var list = await partnerQuery.PaginatedMappedListAsync<PartnerDto, Partner>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.PartnerDtos = list;

        return response;
    }

    public async Task<PartnerGetResponse> Get(int id)
    {
        PartnerGetResponse response = new();

        var partner = await _partnerRepository.GetPartnerByIdAsync(id)
                      ?? throw new NotFoundException("Partner not found");

        var mapping = Mapper.Map<PartnerDto>(partner);
        response.PartnerDto = mapping;

        return response;
    }

    public async Task<int> Update(int faqId, SavePartnerRequest command)
    {
        var data = await _partnerRepository.GetByIdAsync(faqId);
        if (data is null)
            throw new NotFoundException($"ID-si {faqId} olan Partner Yoxdur.");

        var mapping = Mapper.Map(command, data);
        await _partnerRepository.UpdateAsync(mapping);
        return 204;
    }
}