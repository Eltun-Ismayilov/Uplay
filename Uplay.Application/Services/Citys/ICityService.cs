using Uplay.Application.Models.Citys;

namespace Uplay.Application.Services.Citys
{
    public interface ICityService:IBaseService
    {
        Task<List<CityDto>> GetCities();
    }
}
