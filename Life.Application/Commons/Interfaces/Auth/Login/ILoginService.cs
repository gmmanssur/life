using Life.Application.UseCases.Auth.Login;

namespace Life.Application.Commons.Interfaces.Auth.Login
{
    public interface ILoginService
    {
        Task LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}
