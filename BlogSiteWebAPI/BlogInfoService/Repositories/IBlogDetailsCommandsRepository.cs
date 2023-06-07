using BlogInfoService.Models;

namespace BlogInfoService.Repositories
{
    public interface IBlogDetailsCommandsRepository
    {
        int AddBlog(BlogDetails blogDtls);
        int DeleteBlog(int blogId);
    }
}
