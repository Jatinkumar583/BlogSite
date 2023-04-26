using BlogInfoService.Models;
using BlogInfoService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BlogInfoService.Controllers
{
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogUpdateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRegistrationService _userRegistrationService;
        public BlogUpdateController(IConfiguration configuration, IUserRegistrationService userRegistrationService)
        {
            _configuration = configuration;
            _userRegistrationService= userRegistrationService;
           //var client = new MongoClient(_configuration["ConnectionString"]);
           //var dB = client.GetDatabase("BlogSite");
           // dB.GetCollection("tbl");
           //collection

        }
        [HttpPost("user/blogs/add/{blogname}")]
        public IActionResult AddBlog()
        {
            try
            {
                var client = new MongoClient(_configuration["ConnectionString"]);
                var dB = client.GetDatabase("BlogSite");
                //if (bookingDetail != null)
                //{
                //    int bookStatus = _ticketBooking.BookFlight(bookingDetail);
                //    if (bookStatus == 1)
                //    {
                //        return Ok("Flight Booked Successfully.");
                //    }
                //    else
                //    {
                //        return BadRequest("Flight Not Booked.");
                //    }
                //}
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("user/delete/{blogname}")]
        public IActionResult DeleteBlog(string blogname)
        {
            try
            {
                //if (bookingDetail != null)
                //{
                //    int bookStatus = _ticketBooking.BookFlight(bookingDetail);
                //    if (bookStatus == 1)
                //    {
                //        return Ok("Flight Booked Successfully.");
                //    }
                //    else
                //    {
                //        return BadRequest("Flight Not Booked.");
                //    }
                //}
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("user/blog/alluser")]
        public ActionResult<List<UserRegistration>> GetAllUsers()
        {
            try
            {
                return Ok(_userRegistrationService.GetAllUsers());
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
