using Life.Application.UseCases.Auth.Register;

namespace Life.Application.Commons.Interfaces.Auth.Register
{
    public interface IRegisterService
    {
        Task<RegisterResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
    }
}
