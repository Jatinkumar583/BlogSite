using BlogUserCreationService.Models;
using BlogUserCreationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogUserCreationService.Controllers
{
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogUserRegistration : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRegistrationService _userRegistrationService;
        public BlogUserRegistration(IConfiguration configuration, IUserRegistrationService userRegistrationService)
        {
            _configuration = configuration;
            _userRegistrationService = userRegistrationService;
        }    
        [HttpPost("user/register")]
        public IActionResult BlogUserRegister(UserRegistration userRegistration)
        {
            try
            {
                if (userRegistration != null)
                {
                    int addUser = _userRegistrationService.AddUser(userRegistration);
                    if (addUser == 1)
                    {
                        return Ok("User added successfully.");
                    }
                    else
                    {
                        return BadRequest("User not added.");
                    }
                }
                return BadRequest("User not added.");
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
