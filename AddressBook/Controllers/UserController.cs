using AddressBookServices.DTOs;
using AddressBookServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
           _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Regist(RegistDTO regist)
        {
            try
            {
                await _userService.Regist(regist);
                return Ok(true);
            }
            catch (Exception ex) { 
                return BadRequest("Something went wrong "+ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LogInDto logInDto)
        {
            try
            {
                var token = await _userService.LogIn(logInDto);
                return    Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized("Invalid username or password.");
            }
        }
    }
}
