using FluentValidation;

namespace Life.Application.UseCases.Auth.Register.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MaximumLength(100)
                    .WithMessage("Name must be less than 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("Email is required")
                .EmailAddress()
                    .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required")
                .MinimumLength(6) 
                    .WithMessage("Password must be at least 6 characters long");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                    .WithMessage("Passwords do not match");
        }
    }
}
