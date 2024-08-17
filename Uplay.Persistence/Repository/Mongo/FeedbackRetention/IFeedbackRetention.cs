using Uplay.Application.Models.Statistics;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.Repository.Mongo.FeedbackRetention;

public interface IFeedbackRetention
{
    Task RecordFeedback(Feedback feedback);
    Task<FeedbackStatistics<string>> ReadFeedbackRetention(int branchId);
    Task RecordReview(Review review);
    Task<ReviewStatistics<string>> ReadReviewRetention(int branchId);
}