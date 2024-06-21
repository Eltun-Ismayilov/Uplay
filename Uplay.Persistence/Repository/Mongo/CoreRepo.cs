using MongoDB.Driver;

namespace Uplay.Persistence.Repository.Mongo;

public class CoreRepo<T> : ICoreRepo<T>
{
    private readonly IMongoDatabase _mongoDb;

    public CoreRepo(IMongoDatabase mongoDb)
    {
        _mongoDb = mongoDb;
    }

    public async Task WriteQrRetentionToCollection(int branchId)
    {
        await Task.WhenAll(IncrementDailyScan(branchId), IncrementMonthlyScan(branchId));
    }

    public async Task<T> ReadQrRetention(int branchId)
    {
        var collection = _mongoDb.GetCollection<T>(branchId.ToString());

        return await collection.Find<T>(Builders<T>.Filter.Empty).FirstOrDefaultAsync();
    }

    private async Task IncrementDailyScan(int branchId)
    {
        var collection = _mongoDb.GetCollection<T>(branchId.ToString());

        var currentDateKey = DateTime.UtcNow.ToString("dd-MM-yy"); // Format for daily key
        var filter = Builders<T>.Filter.Empty; // No specific filter needed for daily updates
        var update = Builders<T>.Update.Inc($"DailyRetentions.{currentDateKey}", 1);

        await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
    }

    private async Task IncrementMonthlyScan(int branchId)
    {
        var collection = _mongoDb.GetCollection<T>(branchId.ToString());

        var currentMonthKey = DateTime.UtcNow.ToString("MMMM"); // Format for monthly key
        var filter = Builders<T>.Filter.Empty; // No specific filter needed for monthly updates
        var update = Builders<T>.Update.Inc($"MonthlyRetentions.{currentMonthKey}", 1);

        await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
    }
}