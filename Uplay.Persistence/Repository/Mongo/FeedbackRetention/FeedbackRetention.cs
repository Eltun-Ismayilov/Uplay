// using Microsoft.EntityFrameworkCore;
// using MongoDB.Driver;
// using Uplay.Application.Models.Statistics;
// using Uplay.Domain.Entities.Models.Landing;
// using Uplay.Domain.Entities.Models.Landings;
// using Uplay.Persistence.Data.Statistics;
//
// namespace Uplay.Persistence.Repository.Mongo.FeedbackRetention;
//
// public class FeedbackRetention : IFeedbackRetention
// {
//     private const string Collection = "branchStatistics";
//     private const string DateFormat = "dd-MM-yy";
//     private readonly IMongoDatabase _mongoDb;
//     private readonly IRepository<FeedbackType> _feedbacktypeRepository;
//     private readonly ICompanyRepository _companyRepository;
//
//     public FeedbackRetention(IMongoDatabase mongoDb, IRepository<FeedbackType> repository,
//         ICompanyRepository companyRepository)
//     {
//         _mongoDb = mongoDb;
//         _feedbacktypeRepository = repository;
//         _companyRepository = companyRepository;
//     }
//
//     public async Task RecordFeedback(Feedback feedback)
//     {
//         var fbt = await _feedbacktypeRepository.GetByIdAsync(feedback.FeedbackTypeId);
//         var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + feedback.BranchId);
//         var date = feedback.CreatedDate.ToString(DateFormat);
//         var filter = Builders<BranchStatistics>.Filter.Eq(x => x.Date, date);
//         var update = Builders<BranchStatistics>.Update.Inc($"Types.{fbt.Name}", 1);
//
//         await collection.FindOneAndUpdateAsync(filter, update,
//             new FindOneAndUpdateOptions<BranchStatistics> { IsUpsert = true });
//     }
//
//     public async Task RecordReview(Review review)
//     {
//         var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + review.BranchId);
//         var date = review.CreatedDate.ToString(DateFormat);
//         var filter = Builders<BranchStatistics>.Filter.Eq(x => x.Date, date);
//         var update = Builders<BranchStatistics>.Update.Inc($"ReviewCount", 1);
//
//         await collection.FindOneAndUpdateAsync(filter, update,
//             new FindOneAndUpdateOptions<BranchStatistics> { IsUpsert = true });
//     }
//
//     public async Task<Dictionary<string, Dictionary<string, int>>> ReadFeedbackRetention(int branchId)
//     {
//         var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + branchId);
//         var projection = Builders<BranchStatistics>.Projection.Include("Types").Include("Date");
//
//         var feedbackStatisticsList = await collection.Find(Builders<BranchStatistics>.Filter.Empty)
//             .Project<BranchStatistics>(projection).ToListAsync();
//         var feedbackRetentionMap = feedbackStatisticsList
//             .ToDictionary(stat => stat.Date, stat => stat.Types ?? new Dictionary<string, int>());
//
//         return feedbackRetentionMap;
//     }
//
//     public async Task<Dictionary<string, long>> ReadReviewRetention(int branchId)
//     {
//         var collection = _mongoDb.GetCollection<BranchStatistics>($"{Collection}." + branchId);
//         var projection = Builders<BranchStatistics>.Projection.Include("ReviewCount").Include("Date");
//
//         var reviewStatisticsList = await collection.Find(Builders<BranchStatistics>.Filter.Empty)
//             .Project<BranchStatistics>(projection).ToListAsync();
//         var reviewRetentionMap = reviewStatisticsList
//             .ToDictionary(stat => stat.Date, stat => stat.ReviewCount);
//         return reviewRetentionMap;
//     }
//
//     public async Task<ReviewStatistics<string>> ReadFeedbackRetentionInCompany(int companyId)
//     {
//         var company = await _companyRepository.GetTable().Include(x => x.CompanyBranchs)
//             .FirstOrDefaultAsync(x => x.Id == companyId);
//
//         var branchIds = company?.CompanyBranchs.Select(x => x.BranchId);
//
//         foreach (var branchId in branchIds)
//         {
//             var feedbackCounts = new List<FeedbackStatistics<string>>();
//             var collection = _mongoDb.GetCollection<FeedbackStatistics<string>>("feedback." + branchId);
//
//             var feedbacks = await collection.Find(Builders<FeedbackStatistics<string>>.Filter.Empty).ToListAsync();
//
//             foreach (var feedback in feedbacks)
//             {
//                 var date = feedback.Date;
//                 var count = feedbackCounts.FirstOrDefault(x => x.Date == date);
//
//                 if (count == null)
//                 {
//                     count = new FeedbackStatistics<string> { Date = date };
//                     feedbackCounts.Add(count);
//                 }
//
//                 // if (!count.Types.ContainsKey(feedback.Type))
//                 // {
//                 //     count.Types[feedback.Type] = 0;
//                 // }
//                 //
//                 // count.TypeCounts[feedback.Type]++;
//             }
//         }
//
//         return null;
//     }
// }