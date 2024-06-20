using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
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
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IAboutFileRepository aboutFileRepository,
            IAboutTypeRepository aboutTypeRepository)
            : base(mapper, httpContextAccessor)
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
            var about = await _aboutRepository.GetQuery();

            var aboutDto = new AboutDto();

            foreach (var aboutFile in about.AboutFiles)
            {
                var fileUrl = HttpContextAccessor.GeneratePhotoUrl(aboutFile.FileId);

                aboutDto.AboutFiles.Add(new AboutFileDto { Id = aboutFile.Id, File = fileUrl });
            }

            foreach (var aboutType in about.AboutTypes)
            {
                var fileUrl = HttpContextAccessor.GeneratePhotoUrl(aboutType.FileId);

                aboutDto.AboutTypes.Add(new  AboutTypeDto { Id = aboutType.Id,Name=aboutType.Name, File = fileUrl });
            }

            return new AboutGetResponse { AboutDto = aboutDto };
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
