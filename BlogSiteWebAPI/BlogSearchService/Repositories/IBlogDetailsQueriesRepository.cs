using BlogSearchService.Models;

namespace BlogSearchService.Repositories
{
    public interface IBlogDetailsQueriesRepository
    {
        List<BlogDetails> GetAllBlogsByCategory(string category);
        List<BlogDetails> GetAllBlogsByUserId(int userId);
    }
}
