using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Register;
using Shared.DataTransferObject.User; 
using System.Security.Claims;

namespace Presentation.Controllers 
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController( IServiceManger serviceManager)
        {
            _authService = serviceManager.authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(registerDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(loginDto);

            if (!result.IsSuccess)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        // GET: api/auth/check-email?email=test@example.com
        [HttpGet("check-email")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { message = "Email is required." });
            }
            var exists = await _authService.CheckEmailExistsAsync(email);
            return Ok(new { email, exists });
        }

        // POST: api/auth/forgot-password
        [HttpPost("forgot-password")]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.ForgotPasswordAsync(dto.Email);
            return Ok(result);
        }

        // POST: api/auth/reset-password
        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.ResetPasswordAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize] 
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var user = await _authService.GetCurrentUserAsync(userId);
            return user != null ? Ok(user) : NotFound();
        }

        

        // POST: api/auth/logout
        [HttpPost("logout")]
        [Authorize] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "Logout successful. Please discard the token on the client side." });
        }
    }
}
