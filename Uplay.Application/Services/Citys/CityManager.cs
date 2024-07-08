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
            string url = $"https://migration.gov.az/api/v1/office";

            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            string content = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var cities = JsonConvert.DeserializeObject<Root>(content);

                var data = Mapper.Map<List<CityDto>>(cities.data);

                return data;
            }

            throw new Exception("Ex");
        }
    }
}
