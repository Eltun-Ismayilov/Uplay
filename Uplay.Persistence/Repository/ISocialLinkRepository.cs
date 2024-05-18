using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository
{
    public interface ISocialLinkRepository : IRepository<SocialLink>
    {
        Task<SocialLink> GetQuery();
    }
}
