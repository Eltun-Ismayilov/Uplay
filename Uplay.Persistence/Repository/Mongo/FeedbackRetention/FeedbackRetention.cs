using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Uplay.Application.Models.Statistics;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.Repository.Mongo.FeedbackRetention;

public class FeedbackRetention: IFeedbackRetention
{
    private readonly IMongoDatabase _mongoDb;
    private readonly  IRepository<FeedbackType> _feedbacktypeRepository;
    private readonly  ICompanyRepository _companyRepository;

    public FeedbackRetention(IMongoDatabase mongoDb, IRepository<FeedbackType> repository, ICompanyRepository companyRepository)
    {
        _mongoDb = mongoDb;
        _feedbacktypeRepository = repository;
        _companyRepository = companyRepository;
    }
    
    public async Task RecordFeedback(Feedback feedback)
    {
        var fbt = await _feedbacktypeRepository.GetByIdAsync(feedback.FeedbackTypeId);
        var collection = _mongoDb.GetCollection<FeedbackStatistics<string>>("feedback."+feedback.BranchId);
        var date = feedback.CreatedDate.ToString("dd-MM-yy");
        var filter = Builders<FeedbackStatistics<string>>.Filter.Eq(x => x.Date, date);

        var update = Builders<FeedbackStatistics<string>>.Update.Inc($"Types.{fbt.Name}", 1);

        await collection.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<FeedbackStatistics<string>> { IsUpsert = true });
    }
    
    public async Task RecordReview(Review review)
    {
        var collection = _mongoDb.GetCollection<ReviewStatistics<string>>("review."+review.BranchId);
        var date = review.CreatedDate.ToString("dd-MM-yy");
        var filter = Builders<ReviewStatistics<string>>.Filter.Eq(x => x.Date, date);
        
        var update = Builders<ReviewStatistics<string>>.Update.Inc($"reviewCount", 1);

        await collection.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<ReviewStatistics<string>> { IsUpsert = true });
    }
    
    public async Task<Dictionary<string, Dictionary<string, int>>> ReadFeedbackRetention(int branchId)
    {
        var collection = _mongoDb.GetCollection<FeedbackStatistics<string>>("feedback."+ branchId);
        var feedbackStatisticsList = await collection.Find(Builders<FeedbackStatistics<string>>.Filter.Empty).ToListAsync();
        var feedbackRetentionMap = feedbackStatisticsList.ToDictionary(stat => stat.Date, stat => stat.Types);
        return feedbackRetentionMap;
    }
    
    public async Task<Dictionary<string, long>> ReadReviewRetention(int branchId)
    {
        var collection = _mongoDb.GetCollection<ReviewStatistics<string>>("review."+ branchId);
        var reviewStatisticsList = await collection.Find(Builders<ReviewStatistics<string>>.Filter.Empty).ToListAsync();
        var reviewRetentionMap = reviewStatisticsList.ToDictionary(stat => stat.Date, stat => stat.reviewCount);
        return reviewRetentionMap;
    }
    
    public async Task<ReviewStatistics<string>> ReadFeedbackRetentionInCompany(int companyId)
    {
        var company = await _companyRepository.GetTable().Include(x => x.CompanyBranchs).FirstOrDefaultAsync(x => x.Id == companyId);

        var branchIds = company?.CompanyBranchs.Select(x => x.BranchId);
        
        foreach (var branchId in branchIds)
        {
            var feedbackCounts = new List<FeedbackStatistics<string>>();
            var collection = _mongoDb.GetCollection<FeedbackStatistics<string>>("feedback."+ branchId);

            var feedbacks = await collection.Find(Builders<FeedbackStatistics<string>>.Filter.Empty).ToListAsync();

            foreach (var feedback in feedbacks)
            {
                var date = feedback.Date;
                var count = feedbackCounts.FirstOrDefault(x => x.Date == date);

                if (count == null)
                {
                    count = new FeedbackStatistics<string> { Date = date };
                    feedbackCounts.Add(count);
                }

                // if (!count.Types.ContainsKey(feedback.Type))
                // {
                //     count.Types[feedback.Type] = 0;
                // }
                //
                // count.TypeCounts[feedback.Type]++;
            }
        }

        return null;
    }
}