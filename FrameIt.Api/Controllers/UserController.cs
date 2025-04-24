using FrameIt.Core.Dto;
using FrameIt.Core.Services;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrameIt.Api.Controllers
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

        //register
        //[Route("api/[register]")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto request)
        {
            var token = await _userService.RegisterAsync(request);
            if (token == null)
                return BadRequest(new { Massage= "User already exists."});

            return Ok(new { Token = token, Massage = "✅ Well done! Your action was successful. Wishing you continued success!" });
        }

        //login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto request)
        {
            var result = await _userService.LoginAsync(request);
            if (result ==null)
                return Unauthorized("Email or password is incorrect.");

            return Ok(new { Token = result , Massage= "✅ Well done! Your action was successful. Wishing you continued success!" });
        }


        //get user by id
        [HttpGet("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
                return NotFound("User not found.");

            return Ok(new {User= userDto ,Massage= "✅ Well done! Your action was successful. Wishing you continued success!" });
        }


        //update user
        [HttpPut("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserDto request)
        {
            var success = await _userService.UpdateUserAsync(id, request);
            if (success==null)
                return NotFound("User not found.");

            return Ok(new{Succes= success,Massage = "✅ Well done! Your action was successful. Wishing you continued success!" });
        }
    }
}
