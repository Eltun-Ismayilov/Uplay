using MongoDB.Driver;
using Uplay.Persistence.Data.Statistics;

namespace Uplay.Persistence.Repository.Mongo;

public class QrRetentionRepo : IQrRetentionRepo
{
    private const string Collection = "branchStatistics";
    private const string DateFormat = "dd-MM-yy";
    private readonly IMongoDatabase _mongoDb;

    public QrRetentionRepo(IMongoDatabase mongoDb)
    {
        _mongoDb = mongoDb;
    }

    public async Task WriteQrRetentionToCollection(int branchId)
    {
        await IncrementDailyScan(branchId);
    }

    public async Task<Dictionary<string, long>> ReadQrRetention(QrRetFilter filter)
    {
        var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + filter.BranchId);

        var filterBuilder = Builders<BranchStatistics>.Filter;
        var sort = Builders<BranchStatistics>.Sort.Descending(u => u.Date);
        var filterDefinition = filterBuilder.Empty;
        var projection = Builders<BranchStatistics>.Projection.Include("QrRetCount").Include("Date");

        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
        {
            filterDefinition = filterBuilder.And(
                filterDefinition,
                filterBuilder.Gte("Date", filter.StartDate.Value.Date.ToString(DateFormat)),
                filterBuilder.Lte("Date", filter.EndDate.Value.Date.ToString(DateFormat))
            );
        }
        else if (filter.StartDate.HasValue)
        {
            filterDefinition = filterBuilder.And(
                filterDefinition,
                filterBuilder.Gte("Date", filter.StartDate.Value.Date.ToString(DateFormat)),
                filterBuilder.Lte("Date", DateTime.Now.Date.ToString(DateFormat))
            );
        }

        var qrRets = await collection.Find(filterDefinition)
            .Project<BranchStatistics>(projection)
            .Sort(sort)
            .ToListAsync();

        var feedbackRetentionMap = qrRets
            .ToDictionary(stat => stat.Date, stat => stat.QrRetCount);
        return feedbackRetentionMap;
    }

    private async Task IncrementDailyScan(int branchId)
    {
        var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + branchId);
        var date = DateTime.Now.AddDays(-1);
        var currentDateKey = date.ToString(DateFormat); // Format for daily key
        // var currentMonthKey = DateTime.UtcNow.ToString("MMMM"); // Format for monthly key
        var filter = Builders<BranchStatistics>.Filter.Eq(x => x.Date, currentDateKey);
        var update = Builders<BranchStatistics>.Update.Inc($"QrRetCount", 1);
        // var updateMonthKey = Builders<T>.Update.Inc($"MonthlyRetentions.{currentMonthKey}", 1);

        await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
    }
}