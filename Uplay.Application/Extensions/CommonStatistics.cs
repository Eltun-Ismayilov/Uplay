using Uplay.Persistence.Data.Statistics;

namespace Uplay.Application.Extensions;

public class CommonStatistics
{
    public int FeedbackCount { get; set; }
    public int ReviewCount { get; set; }
    public int RatingCount { get; set; }
    public int SongCount { get; set; }
    
    public  List<FeedbackTypeSummary> FeedbackTypeSummary { get; set; }
   
}