using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Uplay.Application.Extensions;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Application.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
               .Where(type => type.GetInterfaces().Any(e => e.IsGenericType && e.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
               .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
                methInfo?.Invoke(instance, new object[] { this });
            }

            CreateMap<IFormFile, AppFile>()
                .ForMember(e => e.Name, d => d.MapFrom(p => p.FileName))
                .ForMember(e => e.Path, d => d.MapFrom(p => p.SaveFileToFolderAndGetPath(FileHelperExtension.FileType.Photo)));
        }
    }
}
