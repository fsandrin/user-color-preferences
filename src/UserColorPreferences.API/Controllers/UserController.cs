using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserColorPreferences.API.Models;
using UserColorPreferences.API.Services.Interfaces;

namespace UserColorPreferences.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.List();

            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
                return NotFound($"User with Id {id} doesn't exist");


            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest("User data not passed");


            var created = await _userService.Insert(user);

            if (created == null)
                return BadRequest("An error has occured please try again");


            return CreatedAtAction("Post", "User", new { created.Id }, created);
        }

        // PUT: api/users
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest("User data not passed");


            var updatedUser = await _userService.Update(user);

            if (updatedUser == null)
                return NotFound($"User with Id {user.Id} doesn't exist");


            return Ok(updatedUser);
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _userService.Delete(id);

            if (!deleted)
                return NotFound($"User with Id {id} doesn't exist");


            return Ok();
        }
    }
}
