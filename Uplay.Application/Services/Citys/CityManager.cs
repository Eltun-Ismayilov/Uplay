using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uplay.Application.Models.Citys;

namespace Uplay.Application.Services.Citys
{
    public class CityManager : BaseManager, ICityService
    {
        public CityManager
            (
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
            )
            : base(mapper, httpContextAccessor)
        {

        }
        public async Task<List<CityDto>> GetCities()
        {
            var city = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 3,
                    Name="Bakı şəhər regional miqrasiya baş idarəsi"
                },
                new CityDto()
                {
                    Id = 4,
                    Name="Lənkəran regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 5,
                    Name="Yevlax regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 6,
                    Name="Ağsu regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 7,
                    Name="Şəki regional miqrasiya idarəsi"
                },

                new CityDto()
                {
                    Id = 8,
                    Name="Xaçmaz regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 9,
                    Name="Gəncə regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 10,
                    Name="Şirvan regional miqrasiya idarəsi"
                },
                new CityDto()
                {
                    Id = 11,
                    Name="Naxçıvan regional miqrasiya baş idarəsi"
                },
            };
            return city;    
        }
    }
}
