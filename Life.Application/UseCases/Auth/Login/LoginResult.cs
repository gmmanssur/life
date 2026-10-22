namespace Life.Application.UseCases.Auth.Login;

public sealed record LoginResult(
    bool Succeeded,
    Guid? UserId,
    string? AccessToken,
    string? ErrorCode,
    IReadOnlyCollection<string> Errors)
{
    public static LoginResult Success(
        Guid userId,
        string accessToken)
    {
        return new LoginResult(
            true,
            userId,
            accessToken,
            null,
            []);
    }

    public static LoginResult Failure(
        string errorCode,
        params string[] errors)
    {
        return new LoginResult(
            false,
            null,
            null,
            errorCode,
            errors);
    }
}