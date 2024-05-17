using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Contacts;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Contacts;

public class ContactManager : BaseManager, IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactManager(IMapper mapper, IContactRepository contactRepository) : base(mapper)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ActionResult<int>> Create(SaveContactRequest command)
    {
        var mapping = Mapper.Map<Contact>(command);
        var data = await _contactRepository.InsertAsync(mapping);
        return data;
    }

    public async Task<ContactGetAllResponse> GetAll(PaginationFilter paginationFilter)
    {
        ContactGetAllResponse response = new();

        var faqQuery = _contactRepository.GetListQuery();

        var list = await faqQuery.PaginatedMappedListAsync<ContactDto, Contact>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.ContactDtos = list;

        return response;
    }

    public async Task<ContactGetResponse> Get(int id)
    {
        ContactGetResponse response = new();

        var contactQuery = await _contactRepository.GetByIdAsync(id);
        var mapping = Mapper.Map<ContactDto>(contactQuery);
        response.ContactDto = mapping;

        contactQuery.IsARead = true;
        await _contactRepository.UpdateAsync(contactQuery);

        return response;
    }
}