using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Application.Models.Files;

public class AppFileDto: BaseDto, IMapFrom<AppFile>
{
    public string Path { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
}