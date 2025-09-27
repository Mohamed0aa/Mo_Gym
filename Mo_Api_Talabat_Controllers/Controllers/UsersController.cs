using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await serviceManager.UserService.GetUserAsync(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = await serviceManager.UserService.CreateUserAsync(createUserDto);
            return Ok(user);
        }

        [HttpPut("{userId:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await serviceManager.UserService.UpdateUserAsync(userId, updateUserDto);
            return Ok(user);
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var result = await serviceManager.UserService.DeleteUserAsync(userId);
            return result ? Ok() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await serviceManager.UserService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("{userId:int}/verify-phone")]
        public async Task<ActionResult> VerifyPhone(int userId)
        {
            var result = await serviceManager.UserService.VerifyPhoneAsync(userId);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{userId:int}/verify-email")]
        public async Task<ActionResult> VerifyEmail(int userId)
        {
            var result = await serviceManager.UserService.VerifyEmailAsync(userId);
            return result ? Ok() : NotFound();
        }
    }
}
