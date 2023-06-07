using BlogInfoService.Models;
using MongoDB.Driver;

namespace BlogInfoService.Repositories
{
    public class BlogDetailsCommandsRepository : IBlogDetailsCommandsRepository
    {
        private readonly IMongoCollection<BlogDetails> _blogDetails;
        public BlogDetailsCommandsRepository(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _blogDetails = database.GetCollection<BlogDetails>(settings.BlogDtlsCollectionName);
        }
        public int AddBlog(BlogDetails blogDtls)
        {
            try
            {
                _blogDetails.InsertOne(blogDtls);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int DeleteBlog(int blogId)
        {
            try
            {
                var itemToRemove = _blogDetails.Find(blog => blog.BlogId == blogId).SingleOrDefault();
                if (itemToRemove != null)
                {
                    _blogDetails.DeleteOne(blog => blog.BlogId == blogId);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
