using FluentValidation;

namespace Life.Application.UseCases.Auth.Login.Validator
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("Email is required")
                .EmailAddress()
                    .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required");
        }
    }
}
