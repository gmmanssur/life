namespace Life.Application.Commons.Interfaces.Auth
{
    public sealed record CreateIdentityUserResult(
        bool Succeeded,
        Guid? UserId,
        IReadOnlyCollection<string> Errors
    );

    public interface IAuthRepository
    {
        Task<bool> EmailExistsAsync(string email);

        Task<CreateIdentityUserResult> CreateUserAsync(
            string name,
            string email,
            string password);
    }
}