using BlogInfoService.Models;

namespace BlogInfoService.Services
{
    public interface IBlogDetailsService
    {
        int AddBlog(BlogDetails blogDtls);
        void DeleteBlog(int blogId);
        //BlogDetails GetBlogById(int blogId);
    }
}
