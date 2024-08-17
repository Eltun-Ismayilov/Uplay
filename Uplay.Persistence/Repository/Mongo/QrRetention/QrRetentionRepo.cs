using MongoDB.Driver;

namespace Uplay.Persistence.Repository.Mongo;

public class QrRetentionRepo<T> : IQrRetentionRepo<T>
{
    private readonly IMongoDatabase _mongoDb;

    public QrRetentionRepo(IMongoDatabase mongoDb)
    {
        _mongoDb = mongoDb;
    }

    public async Task WriteQrRetentionToCollection(int branchId)
    {
        await IncrementDailyScan(branchId);
    }

    public async Task<T> ReadQrRetention(int branchId)
    {
        var collection = _mongoDb.GetCollection<T>("qrret."+branchId);

        return await collection.Find<T>(Builders<T>.Filter.Empty).FirstOrDefaultAsync();
    }

    private async Task IncrementDailyScan(int branchId)
    {
        var collection = _mongoDb.GetCollection<T>("qrret."+branchId);

        var currentDateKey = DateTime.UtcNow.ToString("dd-MM-yy"); // Format for daily key
        var currentMonthKey = DateTime.UtcNow.ToString("MMMM"); // Format for monthly key
        var filter = Builders<T>.Filter.Empty; // No specific filter needed for daily updates
        
        var updateDateKey = Builders<T>.Update.Inc($"DailyRetentions.{currentDateKey}", 1);
        var updateMonthKey = Builders<T>.Update.Inc($"MonthlyRetentions.{currentMonthKey}", 1);

        await Task.WhenAll(collection.UpdateOneAsync(filter, updateDateKey, new UpdateOptions { IsUpsert = true }),
            collection.UpdateOneAsync(filter, updateMonthKey, new UpdateOptions { IsUpsert = true }));
    }
}