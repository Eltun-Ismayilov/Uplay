using MongoDB.Bson;

namespace Uplay.Application.Models.Statistics;

public class ReviewStatistics<T>
{
    public ObjectId _id;
    public T Date { get; set; }
    public long reviewCount { get; set; }
}