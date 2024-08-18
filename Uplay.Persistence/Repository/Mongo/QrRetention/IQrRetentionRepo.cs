using Uplay.Persistence.Data.Statistics;

namespace Uplay.Persistence.Repository.Mongo;

public interface IQrRetentionRepo
{
    Task WriteQrRetentionToCollection(int branchId);
    Task<Dictionary<string, long>> ReadQrRetention(QrRetFilter branchId);
}