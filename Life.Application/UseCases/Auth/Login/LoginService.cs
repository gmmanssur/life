using FluentValidation;
using Life.Application.Commons.Interfaces.Auth;
using Life.Application.Commons.Interfaces.Auth.Login;

namespace Life.Application.UseCases.Auth.Login
{
    public class LoginService(IValidator<LoginRequest> validator, IAuthRepository authRepository, ITokenProvider tokenProvider) : ILoginService
    {

        private readonly IAuthRepository _authRepository = authRepository;
        private readonly ITokenProvider _tokenProvider = tokenProvider;

        public async Task<LoginResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                return LoginResult.Failure("ValidationFailed", errors);
            }

            AuthenticatedUser? user = await _authRepository.AuthenticateAsync(request.Email, request.Password, cancellationToken);

            if (user is null)
                return LoginResult.Failure("InvalidCredentials", "Invalid email or password");

            string accessToken = _tokenProvider.GenerateAccessToken(user);

            return LoginResult.Success(user.Id, accessToken);
        }
    }
}