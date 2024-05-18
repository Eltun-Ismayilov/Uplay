using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Models.Abouts;
using Uplay.Application.Models.Contacts;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Application.Services.Abouts
{
    public class AboutManager : BaseManager, IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutManager(
            IAboutRepository aboutRepository,
            IMapper mapper
            )
            : base(mapper)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<ActionResult<int>> Create(SaveAboutRequest command)
        {
            return await _aboutRepository.InsertAsync(Mapper.Map<About>(command));
        }

        public async Task<AboutGetResponse> Get()
        {
            return new AboutGetResponse { AboutDto = Mapper.Map<AboutDto>(await _aboutRepository.GetQuery()) };
        }

        public async Task<int> Update(SaveAboutRequest command)
        {
            var data = await _aboutRepository.GetQuery();
            if (data is null)
                throw new NotFoundException($"About Yoxdur.");

            var mapping = Mapper.Map(command, data);
            await _aboutRepository.UpdateAsync(mapping);
            return 204;
        }
    }
}
