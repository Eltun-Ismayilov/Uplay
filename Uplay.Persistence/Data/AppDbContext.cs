using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Uplay.Domain.Entities;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Entities.Models.Pricings;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region Companies

        public virtual DbSet<Branch> Branchs { get; set; } = null!;
        public virtual DbSet<BranchCategory> BranchCategories { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyBranch> CompanyBranchs { get; set; } = null!;
        public virtual DbSet<BranchQrCode> BranchQrCodes { get; set; } = null!;

        #endregion

        #region Landings

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<AboutFile> AboutFiles { get; set; } = null!;
        public virtual DbSet<AboutType> AboutTypes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Faq> Faqs { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<PublicReview> PublicReviews { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        public virtual DbSet<SocialLink> SocialLinks { get; set; } = null!;
        public virtual DbSet<YouBusines> YouBusineses { get; set; } = null!;
        public virtual DbSet<FeedbackType> FeedbackTypes { get; set; } = null!;
        public virtual DbSet<RatingBranch> RatingBranchs { get; set; } = null!;
        
        #endregion

        #region Miscs

        public virtual DbSet<AppFile> Files { get; set; } = null!;
        public virtual DbSet<BranchQrRetention> BranchQrRetentions { get; set; } = null!;

        #endregion

        #region PlayLists

        public virtual DbSet<PlayList> PlayLists { get; set; } = null!;
        public virtual DbSet<PlayListStatusHistory> PlayListStatusHistories { get; set; } = null!;

        #endregion

        #region Pricings

        public virtual DbSet<Pricing> Pricings { get; set; } = null!;
        public virtual DbSet<PricingSection> PricingSections { get; set; } = null!;
        public virtual DbSet<PricingType> PricingTypes { get; set; } = null!;

        #endregion

        #region Users

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleClaim> RoleClaims { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=89.117.63.250;Port=5433;Database=Uplay-Dev;User Id=postgres;Password=eltun123;",
                b => b.MigrationsAssembly("Uplay.Persistence"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        var add = entry.Entity;

                        if (add is ICreatedDateEntity trackAdd)
                            trackAdd.CreatedDate = DateTime.UtcNow.AddHours(4);

                        if (add is ISoftDeletedEntity deletedEntity)
                            deletedEntity.Deleted = false;

                        break;

                    case EntityState.Modified:

                        var update = entry.Entity;

                        if (update is IUpdatedDateEntity trackupdate)
                            trackupdate.UpdatedDate = DateTime.UtcNow.AddHours(4);

                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}