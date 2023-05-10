﻿using BlogInfoService.Models;
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
        private readonly IBlogDetailsService _blogDetailsService;
        public BlogUpdateController(IConfiguration configuration, IUserRegistrationService userRegistrationService, IBlogDetailsService blogDetailsService)
        {
            _configuration = configuration;
            _userRegistrationService = userRegistrationService;
            _blogDetailsService = blogDetailsService;
        }
        //[HttpPost("user/blogs/add/{blogname}")]
        [HttpPost("user/blogs/add")]
        public IActionResult AddBlog(BlogDetails blogDetails)
        {
            try
            {
                if (blogDetails != null)
                {
                    int addBlogStatus = _blogDetailsService.AddBlog(blogDetails);
                    if (addBlogStatus == 1)
                    {
                        return Ok("Blog added successfully.");
                    }
                    else
                    {
                        return BadRequest("Blog not added.");
                    }
                }
                return BadRequest("Blog not added.");
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
                int deleteStatus = _blogDetailsService.DeleteBlog(blogId);
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

        //[HttpGet("user/blog/alluser")]
        //public ActionResult<List<UserRegistration>> GetAllUsers()
        //{
        //    try
        //    {
        //        return Ok(_userRegistrationService.GetAllUsers());
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }

        //}
    }
}
