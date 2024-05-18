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
        private readonly IAboutFileRepository _aboutFileRepository;
        private readonly IAboutTypeRepository _aboutTypeRepository;

        public AboutManager(
            IAboutRepository aboutRepository,
            IMapper mapper
,
            IAboutFileRepository aboutFileRepository,
            IAboutTypeRepository aboutTypeRepository)
            : base(mapper)
        {
            _aboutRepository = aboutRepository;
            _aboutFileRepository = aboutFileRepository;
            _aboutTypeRepository = aboutTypeRepository;
        }
        public async Task<ActionResult<int>> Create(SaveAboutRequest command)
        {
            return await _aboutRepository.InsertAsync(Mapper.Map<About>(command));
        }

        public async Task<AboutGetResponse> Get()
        {
            return new AboutGetResponse { AboutDto = Mapper.Map<AboutDto>(await _aboutRepository.GetQuery()) };
        }

        public async Task<int> Update(int id, SaveAboutRequest command)
        {
            var about = await _aboutRepository.GetByAboutIdQuery(id);
            if (about is null)
                throw new NotFoundException($"ID-si {id} olan About Yoxdur.");

            foreach (var aboutFile in about.AboutFiles)
                await _aboutFileRepository.DeleteAsync(aboutFile);

            foreach (var aboutType in about.AboutTypes)
                await _aboutTypeRepository.DeleteAsync(aboutType);

            var mapping = Mapper.Map(command, about);
            await _aboutRepository.UpdateAsync(mapping);
            return 204;
        }
    }
}
