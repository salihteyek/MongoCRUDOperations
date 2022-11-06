using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCRUDOperations.API.Dtos;
using MongoCRUDOperations.API.Models;
using MongoCRUDOperations.API.Services;

namespace MongoCRUDOperations.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync().ConfigureAwait(false);
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User user = new() { Name = userDto.Name };

            await _userService.CreateAsync(user).ConfigureAwait(false);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, UserUpdateDto userDto)
        {
            var user = await _userService.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            User updateUser = new() { Id = user.Id, Name = userDto.Name, Age = userDto.Age, PhoneNumbers = userDto.PhoneNumbers };
            await _userService.UpdateAsync(id, updateUser).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.DeleteAsync(user.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
