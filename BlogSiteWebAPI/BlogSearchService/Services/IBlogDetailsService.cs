using BlogSearchService.Models;

namespace BlogSearchService.Services
{
    public interface IBlogDetailsService
    {
        List<BlogDetails> GetAllBlogsByCategory(string category);
    }
}
