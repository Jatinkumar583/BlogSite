using BlogInfoService.Models;
using MongoDB.Driver;

namespace BlogInfoService.Services
{
    public class BlogDetailsService : IBlogDetailsService
    {
        private readonly IMongoCollection<BlogDetails> _blogDetails;
        public BlogDetailsService(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _blogDetails = database.GetCollection<BlogDetails>(settings.UserRegCollectionName);
        }
        public int AddBlog(BlogDetails blogDtls)
        {
            _blogDetails.InsertOne(blogDtls);
            return 1;
        }
        public void DeleteBlog(int blogId)
        {
            _blogDetails.DeleteOne(blog => blog.BlogId == blogId);
        }
        
        //public BlogDetails GetBlogById(int blogId)
        //{
        //    return _blogDetails.Find(blog => blog.BlogId==blogId).FirstOrDefault();
        //}
    }
}
