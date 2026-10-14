using Life.Application.Commons.Interfaces.Auth;
using Life.Application.Commons.Interfaces.Auth.Login;

namespace Life.Application.UseCases.Auth.Login
{
    public class LoginService(IAuthRepository authRepository) : ILoginService
    {
        private readonly IAuthRepository _authRepository = authRepository;

        public async Task LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            if (!await _authRepository.EmailExistsAsync(request.Email))
                throw new InvalidOperationException("Invalid email or password");
        }
    }
}