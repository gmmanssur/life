using Life.Application.UseCases.Auth.Login;

namespace Life.Application.Commons.Interfaces.Auth.Login
{
    public interface ILoginService
    {
        Task<LoginResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}
