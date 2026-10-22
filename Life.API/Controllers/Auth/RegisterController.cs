using Life.Application.Commons.Interfaces.Auth.Register;
using Life.Application.UseCases.Auth.Register;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class RegisterController(IRegisterService registerService) : ControllerBase
    {
        readonly IRegisterService _registerService = registerService;

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            RegisterResult result = await _registerService.RegisterAsync(request, cancellationToken);

            if (result.Succeeded)
            {
                return StatusCode(
                    StatusCodes.Status201Created,
                    new { userId = result.UserId }
                );
            }

            if (result.ErrorCode == "ValidationFailed")
                return BadRequest(new { errors = result.Errors });

            if (result.ErrorCode == "EmailAlreadyExists")
                return Conflict(new { errors = result.Errors });

            return BadRequest(new { errors = result.Errors });
        }
    }
}
