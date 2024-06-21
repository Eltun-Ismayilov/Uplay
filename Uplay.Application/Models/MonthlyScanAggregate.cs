using MongoDB.Bson;

namespace Uplay.Application.Models;

public class MonthlyScanAggregate
{
    public ObjectId Id { get; set; }
    public Dictionary<string, int> DailyRetentions { get; set; }
    public Dictionary<string, int> MonthlyRetentions { get; set; }
    
    public MonthlyScanAggregate()
    {
        DailyRetentions = new Dictionary<string, int>();
        MonthlyRetentions = new Dictionary<string, int>();
    }
}