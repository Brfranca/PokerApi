using Microsoft.AspNetCore.Mvc;
using Poker.Service.DTOs.User;
using Poker.Service.Interfaces;

namespace Poker.Api.Controllers
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

        [HttpPost("Create")]
        public IActionResult Insert(UserRequest user)
        {
            _userService.Create(user);
            return Created();
        }

        [HttpPatch("Update")]
        public IActionResult Update(UserUpdateRequest user)
        {
            _userService.Update(user);

            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            return Ok(user);
        }
    }
}
