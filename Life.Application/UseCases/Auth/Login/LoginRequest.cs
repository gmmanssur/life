namespace Life.Application.UseCases.Auth.Login
{
    public sealed class LoginRequest
    {
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
    }
}
