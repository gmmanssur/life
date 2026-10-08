namespace Life.Application.Commons.Interfaces.Homework
{
    public interface IHomeworkRepository
    {
        Task AddAsync(Domain.Entities.Homework homework, CancellationToken cancellationToken);
        Task<List<Domain.Entities.Homework>> GetAllAsync(CancellationToken cancellationToken);
        Task<Domain.Entities.Homework?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Domain.Entities.Homework> UpdateAsync(Domain.Entities.Homework homework, CancellationToken cancellationToken);
        Task DeleteAsync(Domain.Entities.Homework homework, CancellationToken cancellationToken);
    }
}
