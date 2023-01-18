using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public UserController(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpadateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LogInUser([FromBody] User user)
        {
            
            var logInUser = _userService.LogInUser(user.userName, user.password);
            if (logInUser != null)
            {
                return Ok("You are Already Log In :) ");
            }

            else return BadRequest("Invalid Username And Password");
        }


    }
}
