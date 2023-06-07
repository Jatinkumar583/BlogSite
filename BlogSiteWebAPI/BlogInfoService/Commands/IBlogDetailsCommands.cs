using BlogInfoService.Models;

namespace BlogInfoService.Commands
{
    public interface IBlogDetailsCommands
    {
        int AddBlogData(BlogDetails blogDtls);
        int DeleteBlogData(int blogId);
    }
}
