using AutoMapper;
using Uplay.Application.Mappings;

namespace Uplay.Application.Models.Citys
{
    public class CityDto : IMapFrom<Datum>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Datum, CityDto>()
             .ForMember(x => x.Id, z => z.MapFrom(y => y.id))
             .ForMember(x => x.Name, z => z.MapFrom(y => y.name_az));

        }
    }
}
