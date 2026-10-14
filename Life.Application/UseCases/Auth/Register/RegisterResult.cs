namespace Life.Application.UseCases.Auth.Register
{
    public sealed record RegisterResult(
        bool Succeeded,
        Guid? UserId,
        string? ErrorCode,
        IReadOnlyCollection<string> Errors)
    {
        public static RegisterResult Success(Guid userId) =>
            new(true, userId, null, []);

        public static RegisterResult Failure(string errorCode, params string[] errors) 
            => new(false, null, errorCode, errors);
    }
}
