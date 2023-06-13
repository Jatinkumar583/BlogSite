using BlogUserCreationService.Commands;
using BlogUserCreationService.Models;
using BlogUserCreationService.Queries;
using BlogUserCreationService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogUserCreationService.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserRegQueries _userRegistrationQueries;
        private readonly IUserRegCommands _userRegistrationCommands;
        public UsersController(IJWTManagerRepository jWTManager,IUserRegistrationService userRegistrationService,
            IUserRegQueries userRegistrationQueries, IUserRegCommands userRegistrationCommands)
        {
            iJWTManager = jWTManager;
            _userRegistrationService = userRegistrationService;
            _userRegistrationQueries = userRegistrationQueries;
            _userRegistrationCommands = userRegistrationCommands;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User userdata)
        {
            var token = iJWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult UserRegistration(UserRegistration userdata)
        {
            userdata.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            userdata.UserId= Convert.ToInt32(DateTime.UtcNow.Day+DateTime.UtcNow.Month+DateTime.UtcNow.Year+DateTime.UtcNow.Hour+
                DateTime.UtcNow.Minute+DateTime.UtcNow.Second);
            //userdata.UserId= Convert.ToInt32(DateTime.UtcNow.day);
            userdata.CreatedBy= userdata.UserId;
            userdata.CreatedOn= DateTime.UtcNow;
            _userRegistrationCommands.AddUserData(userdata);
            //_userRegistrationService.AddUser(userdata);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("getuserdetails")]
        public IActionResult GetUserDetails(User user)
        {
            if (user != null)
            {
                return Ok(_userRegistrationQueries.GetUserDataInfo(user));
            }
            return BadRequest();

        }
    }
}
