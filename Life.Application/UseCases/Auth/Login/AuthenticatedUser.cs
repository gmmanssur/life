namespace Life.Application.UseCases.Auth.Login
{
    public sealed record AuthenticatedUser(Guid Id, string Name, string Email);
}
