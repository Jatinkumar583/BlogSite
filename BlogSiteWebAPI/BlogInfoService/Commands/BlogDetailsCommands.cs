using BlogInfoService.Models;
using BlogInfoService.Repositories;

namespace BlogInfoService.Commands
{
    public class BlogDetailsCommands : IBlogDetailsCommands
    {
        private readonly IBlogDetailsCommandsRepository _commandRepository;
        public BlogDetailsCommands(IBlogDetailsCommandsRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public int AddBlogData(BlogDetails blogDtls)
        {
          return  _commandRepository.AddBlog(blogDtls);
        }

        public int DeleteBlogData(int blogId)
        {
          return  _commandRepository.DeleteBlog(blogId);
        }
    }
}
