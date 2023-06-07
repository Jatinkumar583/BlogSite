using BlogInfoService.Commands;
using BlogInfoService.Models;
using BlogInfoService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BlogInfoService.Controllers
{
    [Authorize]
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogUpdateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBlogDetailsService _blogDetailsService;
        private readonly IBlogDetailsCommands _blogDetailsCommands;
        public BlogUpdateController(IConfiguration configuration, IBlogDetailsService blogDetailsService, IBlogDetailsCommands blogDetailsCommands)
        {
            _configuration = configuration;
            _blogDetailsService = blogDetailsService;
            _blogDetailsCommands = blogDetailsCommands;
        }
        //[HttpPost("user/blogs/add/{blogname}")]
        [HttpPost("user/blogs/add")]
        public IActionResult AddBlog(BlogDetails blogDetails)
        {
            try
            {
                if (blogDetails != null)
                {
                    if (string.IsNullOrEmpty(blogDetails.Id))
                    {
                        blogDetails.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                    }
                    blogDetails.BlogId = Convert.ToInt32(DateTime.UtcNow.Day + DateTime.UtcNow.Month + DateTime.UtcNow.Year + DateTime.UtcNow.Hour +
                DateTime.UtcNow.Minute + DateTime.UtcNow.Second);
                    //int addBlogStatus = _blogDetailsService.AddBlog(blogDetails);
                    int addBlogStatus = _blogDetailsCommands.AddBlogData(blogDetails);
                    if (addBlogStatus == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpDelete("user/delete/{blogname}")]
        [HttpDelete("user/delete")]
        public IActionResult DeleteBlog(int blogId)
        {
            try
            {
                //int deleteStatus = _blogDetailsService.DeleteBlog(blogId);
                int deleteStatus = _blogDetailsCommands.DeleteBlogData(blogId);
                if (deleteStatus == 1)
                {
                    return Ok("Blog delete successfully.");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
