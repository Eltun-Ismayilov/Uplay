using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Models.SocialLinks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.SocialLinks
{
    public class SocialLinkService : BaseManager, ISocialLinkService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public SocialLinkService(ISocialLinkRepository socialLinkRepository, IMapper mapper) : base(mapper)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public async Task<ActionResult<int>> Create(SaveSocialLinkRequest command)
        {
            var mapping = Mapper.Map<SocialLink>(command);
            var data = await _socialLinkRepository.InsertAsync(mapping);
            return data;
        }

        public async Task<SocialLinkGetResponse> Get()
        {
            SocialLinkGetResponse response = new();

            var faqQuery = await _socialLinkRepository.GetQuery();
            var mapping = Mapper.Map<SocialLinkDto>(faqQuery);
            response.SocialLinkDto = mapping;

            return response;
        }

       

        public async Task<int> Update(int id, SaveSocialLinkRequest command)
        {
            var data = await _socialLinkRepository.GetByIdAsync(id);
            if (data is null)
                throw new NotFoundException($"ID-si {id} olan SocialLink Yoxdur.");

            var mapping = Mapper.Map(command, data);
            await _socialLinkRepository.UpdateAsync(mapping, true);
            return 204;
        }
    }
}
