using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Common;
using MakersApiWeb.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace MakersApiWeb.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController(AppDbContext context) : BaseController
    {
        private readonly AppDbContext _context = context;

        // Get all users 
        [Route("getAllUsers")]
        [ResponseCache(Duration = 100)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await Mediator.Send(new UserQueryAllCommand());
            return Ok(users);
        }

        // Get user for id
        [Route("getUserById/{id}")]
        [ResponseCache(Duration = 100)]
        [HttpGet]
        public async Task<ActionResult<UserDto>?> GetUserById(int id)
        {
            var user = await Mediator.Send(new UserQueryByIdCommand { Id = id });
            return user;
        }

        // Update user
        [Route("updateUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateCommand request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        // Create user
        [Route("createUser")]
        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(UserInsCommand request)
        {
            var result = await Mediator.Send(request);
            return CreatedAtAction(nameof(CreateUser), new { id = result.Id }, result);
        }

        // Delete user
        [Route("deleteUser/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            await Mediator.Send(new UserDelCommand { Id = id });
            return NoContent();
        }
    }
}
