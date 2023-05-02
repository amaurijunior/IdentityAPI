using IdentityAPI.Data.DTOs;
using IdentityAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _UserService;

        public UserController(UserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            throw new NotImplementedException();
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser(UserDTO User)
        {
            await _UserService.CreateUser(User);
            return Ok("Usuário criado!");
        }

        [HttpPut]
        public IActionResult UpdateUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteUser()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO Login) {

            var token = await _UserService.Login(Login);

            return Ok(token);
        }
    }

}
