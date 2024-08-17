using MongoDB.Bson;

namespace Uplay.Persistence.Repository.Mongo;

public interface IQrRetentionRepo<T>
{
    Task WriteQrRetentionToCollection(int branchId);
    Task<T> ReadQrRetention(int branchId);
}