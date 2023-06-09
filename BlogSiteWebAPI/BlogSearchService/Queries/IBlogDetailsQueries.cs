using BlogSearchService.Models;

namespace BlogSearchService.Queries
{
    public interface IBlogDetailsQueries
    {
        List<BlogDetails> GetAllBlogsDataByCategory(string category);
        List<BlogDetails> GetAllBlogsDataByUserId(int userId);
    }
}
