// using Uplay.Application.Models.Statistics;
// using Uplay.Domain.Entities.Models.Landing;
// using Uplay.Domain.Entities.Models.Landings;
//
// namespace Uplay.Persistence.Repository.Mongo.FeedbackRetention;
//
// public interface IFeedbackRetention
// {
//     Task RecordFeedback(Feedback feedback);
//     Task<Dictionary<string, Dictionary<string, int>>> ReadFeedbackRetention(int branchId);
//     Task RecordReview(Review review);
//     Task<Dictionary<string, long>> ReadReviewRetention(int branchId);
// }