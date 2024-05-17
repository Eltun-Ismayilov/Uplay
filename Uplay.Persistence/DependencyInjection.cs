using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Uplay.Persistence.Data;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var conStr = configuration["ConnectionStrings"];

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conStr,
                b => b.MigrationsAssembly(typeof(DependencyInjection)
                    .Assembly
                    .FullName)));

            services.AddRepos();

            return services;
        }

        private static IServiceCollection AddRepos(this IServiceCollection services)
        {
            // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //
            // var assembly = Assembly.GetExecutingAssembly();
            // var types = assembly.GetTypes()
            //     .Where(e =>
            //         e.IsClass
            //         && e.IsSubclassOf(typeof(Repository<>)))
            //     .ToList();
            //
            // foreach (var type in types)
            // {
            //     var nestedInterface =
            //         type.GetInterfaces().First(x => x.GetInterfaces().Contains(typeof(IRepository<>)));
            //
            //     services.AddScoped(nestedInterface, type);
            // }
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IFaqRepository), typeof(FaqRepository));
            services.AddScoped(typeof(IPartnerRepository), typeof(PartnerRepository));    
            services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
            services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));
            services.AddScoped(typeof(IPublicReviewRepository), typeof(PublicReviewRepository));
            services.AddScoped(typeof(IAboutRepository), typeof(AboutRepository));

            return services;
        }
    }
}