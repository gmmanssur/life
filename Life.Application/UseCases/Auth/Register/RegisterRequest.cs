namespace Life.Application.UseCases.Auth.Register
{
    public class RegisterRequest
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string ConfirmPassword { get; private set; } = string.Empty;
    }
}
