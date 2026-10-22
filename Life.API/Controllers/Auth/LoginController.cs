using Life.Application.Commons.Interfaces.Auth.Login;
using Life.Application.UseCases.Auth.Login;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        readonly ILoginService _loginService = loginService;
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            LoginResult result = await _loginService.LoginAsync(request, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    userId = result.UserId,
                    accessToken = result.AccessToken
                });
            }

            if (result.ErrorCode == "ValidationFailed")
                return BadRequest(new { errors = result.Errors });

            if (result.ErrorCode == "EmailAlreadyExists")
                return Conflict(new { errors = result.Errors });

            return BadRequest(new { errors = result.Errors });
        }
    }
}