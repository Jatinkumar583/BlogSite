using BlogUserCreationService.Commands;
using BlogUserCreationService.Models;
using BlogUserCreationService.Queries;
using BlogUserCreationService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogUserCreationService.Controllers
{
    [Authorize]
    [Route("api/v1.0/blogsite")]
    [ApiController]
    public class BlogUserRegistration : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRegQueries _userRegistrationQueries;
        private readonly IUserRegCommands _userRegistrationCommands;
        public BlogUserRegistration(IConfiguration configuration,IUserRegCommands userRegCommands, IUserRegQueries userRegQueries)
        {
            _configuration = configuration;
            _userRegistrationCommands = userRegCommands;
            _userRegistrationQueries = userRegQueries;
        }    
        [HttpPost("user/register")]
        public IActionResult BlogUserRegister(UserRegistration userRegistration)
        {
            try
            {
                if (userRegistration != null)
                {
                    if (string.IsNullOrEmpty(userRegistration.Id))
                    {
                        userRegistration.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                    }
                    int addUser = _userRegistrationCommands.AddUserData(userRegistration);
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
