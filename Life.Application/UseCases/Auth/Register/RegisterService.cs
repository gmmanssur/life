using FluentValidation;
using FluentValidation.Results;
using Life.Application.Commons.Interfaces.Auth;
using Life.Application.Commons.Interfaces.Auth.Register;

namespace Life.Application.UseCases.Auth.Register
{
    public class RegisterService(IValidator<RegisterRequest> validator, IAuthRepository authRepository) : IRegisterService
    {
        readonly IValidator<RegisterRequest> _validator = validator;
        readonly IAuthRepository _authRepository = authRepository;

        public async Task<RegisterResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await _validator.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                string[] errors = [.. validation.Errors
                    .Select(error =>
                        $"{error.PropertyName}: {error.ErrorMessage}")];

                return RegisterResult.Failure(
                    "ValidationFailed",
                    errors);
            }

            cancellationToken.ThrowIfCancellationRequested();

            if (await _authRepository.EmailExistsAsync(request.Email))
            {
                return RegisterResult.Failure(
                    "EmailAlreadyExists",
                    "Email already registered");
            }

            CreateIdentityUserResult creation = await _authRepository.CreateUserAsync(request.Name, request.Email, request.Password);

            if (!creation.Succeeded)
                return RegisterResult.Failure("IdentityCreationFailed", [.. creation.Errors]);

            return RegisterResult.Success(creation.UserId!.Value);
        }
    }
}
