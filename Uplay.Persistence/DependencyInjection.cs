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

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(conStr));

            services.AddRepos();

            return services;
        }
        private static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly
                .GetTypes()
                .Where(e => !e.IsAbstract
                 && e.BaseType is not null
                 && e.BaseType.IsGenericType
                 && e.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>))
                .ToList();

            foreach (var type in types)
            {
                var data = services.AddScoped(type);
            }
            return services;
        }
    }
}
