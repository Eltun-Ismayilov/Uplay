using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.Repository
{
    public interface IPublicReviewRepository : IRepository<PublicReview>
    {
        IQueryable<PublicReview> GetListQuery();
        Task<PublicReview> GetPublicReviewByIdAsync(int id);
    }
}
