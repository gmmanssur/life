using Life.Application.UseCases.Auth.Login;

namespace Life.Application.Commons.Interfaces.Auth
{
    public interface ITokenProvider
    {
        string GenerateAccessToken(AuthenticatedUser user);
    }
}
