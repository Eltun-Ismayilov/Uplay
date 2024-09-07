using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Persistence.Data.Statistics;

namespace Uplay.Persistence.Repository.Mongo;

public class QrRetentionRepo : IQrRetentionRepo
{
    private readonly IRepository<BranchQrRetention> _branchQrRetentionRepository;

    public QrRetentionRepo( IRepository<BranchQrRetention> branchQrRetentionRepository)
    {
        _branchQrRetentionRepository = branchQrRetentionRepository;
    }

    public async Task WriteQrRetentionToCollection(int branchId)
    {
        await IncrementDailyScan(branchId);
    }

    public async Task<Dictionary<string, long>> ReadQrRetention(QrRetFilter filter)
    {
        var query = _branchQrRetentionRepository.GetQuery();
        
        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
        {
            var formattedStartDate = filter.StartDate.Value.ToString("yyyy-MM-dd");
            var formattedEndDate = filter.EndDate.HasValue ? filter.EndDate.Value.ToString("yyyy-MM-dd")
                : DateTime.Now.ToString("yyyy-MM-dd");
            query = query.Where(x => string.Compare(x.Date, formattedStartDate) >= 0 &&
                                     string.Compare(x.Date, formattedEndDate) <= 0);
        }
        else if (filter.StartDate.HasValue)
        {
            var formattedStartDate = filter.StartDate.Value.ToString("yyyy-MM-dd");
            query = query.Where(x => string.Compare(x.Date, formattedStartDate) >= 0 &&
                                     String.CompareOrdinal(x.Date, DateTime.Now.ToString("yyyy-MM-dd")) <= 0);
        }

        var qrRets = await query
            .Select(x => new { x.Date, x.QrRetCount })
            .OrderBy(x=>x.Date)
            .ToListAsync();

        var feedbackRetentionMap = qrRets
            .ToDictionary(stat => stat.Date, stat => stat.QrRetCount);

        return feedbackRetentionMap;
    }

    private async Task IncrementDailyScan(int branchId)
    {
        var date = DateTime.UtcNow;
        var currentDateKey = date.ToString("yyyy-MM-dd"); // Use your DateFormat here
        
        var branchStatistic = await _branchQrRetentionRepository.GetQuery()
            .FirstOrDefaultAsync(x => x.BranchId == branchId && x.Date == currentDateKey);
        
        if (branchStatistic != null)
        {
            branchStatistic.QrRetCount += 1;
        }
        else
        {
            branchStatistic = new BranchQrRetention()
            {
                BranchId = branchId,
                Date = currentDateKey,
                QrRetCount = 1
            };
            await _branchQrRetentionRepository.GetTable().AddAsync(branchStatistic);
        }
        
        await _branchQrRetentionRepository.SaveChangesAsync();
    }
}