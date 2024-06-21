using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Uplay.Persistence.Data;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Concrete;
using Uplay.Persistence.Repository.Mongo;

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
            
            services.AddSingleton<IMongoClient>(sp =>
            { 
                var conStr = configuration["MongoConStr"];
                return new MongoClient(conStr);
            });
            
            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var database = configuration["MongoDb"];
                return client.GetDatabase(database);
            });

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
            services.AddScoped(typeof(ISocialLinkRepository), typeof(SocialLinkRepository));
            services.AddScoped(typeof(IAboutFileRepository), typeof(AboutFileRepository));
            services.AddScoped(typeof(IAboutTypeRepository), typeof(AboutTypeRepository));
            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
            services.AddScoped(typeof(IPricingRepository), typeof(PricingRepository));
            services.AddScoped(typeof(IPricingSectionRepository), typeof(PricingSectionRepository));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ICompanyBranchRepository), typeof(CompanyBranchRepository));
            services.AddScoped(typeof(IBranchRepository), typeof(BranchRepository));
            services.AddScoped(typeof(IBranchQrCodeRepository), typeof(BranchQrCodeRepository));
            
            services.AddScoped(typeof(ICoreRepo<>), typeof(CoreRepo<>));
            return services;
        }
    }
}