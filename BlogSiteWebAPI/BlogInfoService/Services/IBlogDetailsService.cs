using BlogInfoService.Models;

namespace BlogInfoService.Services
{
    public interface IBlogDetailsService
    {
        int AddBlog(BlogDetails blogDtls);
        int DeleteBlog(int blogId);        
    }
}
