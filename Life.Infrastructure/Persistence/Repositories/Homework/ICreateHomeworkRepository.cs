namespace Life.Infrastructure.Persistence.Repositories.Homework
{
    public interface ICreateHomeworkRepository
    {
        Task AddAsync(Domain.Entities.Homework? homework, CancellationToken cancellationToken);
    }
}
