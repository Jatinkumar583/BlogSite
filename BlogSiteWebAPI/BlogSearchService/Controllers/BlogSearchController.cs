using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSearchService.Controllers
{
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogSearchController : ControllerBase
    {
        [HttpGet("blogs/info/{category}")]
        public IActionResult GetBlogsByCategory(string category)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("user/getall")]
        public IActionResult GetAllBlogUsers()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
