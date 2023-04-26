using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogUserCreationService.Controllers
{
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogUserRegistration : ControllerBase
    {
        [HttpPost("user/register")]
        public IActionResult BlogUserRegister()
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
    }
}
