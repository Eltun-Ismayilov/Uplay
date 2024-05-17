
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Persistence.Data;

namespace Uplay.Persistence.Repository.Concrete
{
    public class PublicReviewRepository : BaseRepository<PublicReview>, IPublicReviewRepository
    {
        public PublicReviewRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<PublicReview> GetListQuery()
        {
            var publicReviewListquery = AsQueryable().AsNoTracking()
                .Include(x => x.File)
                .OrderByDescending(x => x.Id);

            return publicReviewListquery;
        }

        public async Task<PublicReview> GetPublicReviewByIdAsync(int id)
        {
            var publicReview = await AsQueryable().AsNoTracking()
                .Include(x => x.File)
                .FirstOrDefaultAsync(x => x.Id == id);

            return publicReview;
        }
    }
}
