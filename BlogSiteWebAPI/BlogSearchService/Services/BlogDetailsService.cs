using BlogSearchService.Models;
using MongoDB.Driver;

namespace BlogSearchService.Services
{
    public class BlogDetailsService : IBlogDetailsService
    {
        private readonly IMongoCollection<BlogDetails> _blogDetails;

        public BlogDetailsService(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _blogDetails = database.GetCollection<BlogDetails>(settings.BlogDtlsCollectionName);

        }
        public List<BlogDetails> GetAllBlogsByCategory(string category)
        {
            return _blogDetails.Find(blogs => blogs.Category==category).ToList();
        }
    }
}
