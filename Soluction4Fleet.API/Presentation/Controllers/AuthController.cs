
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs;
using Soluction4Fleet.API.Application.Interfaces.Services;

namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginFleetRequest request)
        {
            try
            {
                var response = await _authService.Authenticate(request);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound($"Usuário não foi encontrado.");
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
