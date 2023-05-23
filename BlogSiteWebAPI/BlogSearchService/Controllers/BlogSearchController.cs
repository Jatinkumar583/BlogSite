using BlogSearchService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSearchService.Controllers
{
    [Authorize]
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogSearchController : ControllerBase
    {
        private readonly IBlogDetailsService _blogDetailsService; 
        private readonly IUserRegistrationService _userRegistrationService;
        public BlogSearchController(IBlogDetailsService blogDetailsService, IUserRegistrationService userRegistrationService)
        {
            _blogDetailsService = blogDetailsService;
            _userRegistrationService = userRegistrationService;
        }
        [HttpGet("blogs/info/{category}")]
        public IActionResult GetBlogsByCategory(string category)
        {
            try
            {
                if (category!=null)
                {
                    return Ok(_blogDetailsService.GetAllBlogsByCategory(category));
                }
                else
                {
                    return BadRequest();
                }                
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("blogs/user/{userId}")]
        public IActionResult GetBlogsByUserId(int userId)
        {
            try
            {
                return Ok(_blogDetailsService.GetAllBlogsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/getall")]
        public IActionResult GetAllBlogUsers()
        {
            try
            {
                return Ok(_userRegistrationService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
