using MongoDB.Bson;

namespace Uplay.Persistence.Data.Statistics;

public class BranchStatistics
{
    public ObjectId _id;
    public string Date { get; set; }
    public long QrRetCount { get; set; }
}