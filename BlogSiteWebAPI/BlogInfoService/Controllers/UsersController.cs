﻿using BlogInfoService.Models;
using BlogInfoService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogInfoService.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            iJWTManager = jWTManager;
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

        
    }
}
