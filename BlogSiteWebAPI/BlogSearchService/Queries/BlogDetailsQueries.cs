using BlogSearchService.Models;
using BlogSearchService.Repositories;

namespace BlogSearchService.Queries
{
    public class BlogDetailsQueries : IBlogDetailsQueries
    {
        private readonly IBlogDetailsQueriesRepository _queriesRepository;
        public BlogDetailsQueries(IBlogDetailsQueriesRepository queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }
        public List<BlogDetails> GetAllBlogsDataByCategory(string category)
        {
           return _queriesRepository.GetAllBlogsByCategory(category);
        }

        public List<BlogDetails> GetAllBlogsDataByUserId(int userId)
        {
            return _queriesRepository.GetAllBlogsByUserId(userId);
        }
    }
}
