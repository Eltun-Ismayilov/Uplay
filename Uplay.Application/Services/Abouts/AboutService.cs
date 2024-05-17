using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models.Abouts;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Abouts
{
    public class AboutService : BaseManager, IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(
            IAboutRepository aboutRepository,
            IMapper mapper
            )
            : base(mapper)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<ActionResult<int>> Create(SaveAboutRequest command)
        {
            var mapping = Mapper.Map<About>(command);

            var data = await _aboutRepository.InsertAsync(mapping);

            return data;
        }
    }
}
