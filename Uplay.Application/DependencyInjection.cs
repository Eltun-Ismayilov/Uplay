using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Uplay.Application.Mappings;
using Uplay.Application.Services;

namespace Uplay.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();

            //services.AddAutoMapper(typeof(AssemblyMappingProfile));

            services.AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.DisableDataAnnotationsValidation = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.
                  GetTypes()
                 .Where(e =>
                     e.IsClass
                 && !e.IsAbstract
                 &&  e.GetInterfaces()
                      .Contains(typeof(IBaseService)))
                      .ToList();

            foreach (var type in types)
            {
                var nestedInterface = type.GetInterfaces().First(x => x.GetInterfaces().Contains(typeof(IBaseService)));

                services.AddScoped(nestedInterface, type);
            }

            return services;
        }
    }
}
