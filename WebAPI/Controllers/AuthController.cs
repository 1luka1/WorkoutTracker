using Application.DTOs.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto) { 
            var result = await _authService.RegisterAsync(dto);
            if (result.IsFailure)
                return BadRequest(new { error = result.ErrorMessage });

            return Ok(result.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto) { 
            var result = await _authService.LoginAsync(dto);
            if (result.IsFailure)
                return Unauthorized(new { error = result.ErrorMessage });
            return Ok(result.Data);
        }
    }
}
