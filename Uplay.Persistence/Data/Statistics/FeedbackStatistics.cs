using MongoDB.Bson;

namespace Uplay.Application.Models.Statistics;

public class FeedbackStatistics<T>
{
    public ObjectId _id;
    public T Date { get; set; }
    public Dictionary<string, int> Types { get; set; } = new Dictionary<string, int>();
}