using Life.Application.Commons.Interfaces.Auth.Login;
using Life.Application.UseCases.Auth.Login;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            await _loginService.LoginAsync(request, cancellationToken);

            return Ok();
        }
    }
}