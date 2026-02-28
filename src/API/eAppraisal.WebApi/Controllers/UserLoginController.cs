using Microsoft.AspNetCore.Mvc;
using Application.HR;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;
        public UserLoginController(IUserLoginService service) => _service = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string passwordHash)
        {
            var result = await _service.AuthenticateAsync(username, passwordHash);
            return result.IsSuccess ? Ok(result.Value) : Unauthorized(new { error = result.Error });
        }

        [HttpPost("lock/{userId}")]
        public async Task<IActionResult> LockAccount(long userId)
        {
            var result = await _service.LockAccountAsync(userId);
            return result.IsSuccess ? Ok(result.Value) : NotFound(new { error = result.Error });
        }
    }
}
