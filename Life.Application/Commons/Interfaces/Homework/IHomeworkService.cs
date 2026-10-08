using Life.Application.UseCases.Homeworks;

namespace Life.Application.Commons.Interfaces.Homework
{
    public interface IHomeworkService
    {
        Task<Domain.Entities.Homework> ExecuteCreateAsync(HomeworkRequest request, CancellationToken cancellationToken);
        Task<List<Domain.Entities.Homework>> ExecuteGetAllAsync(CancellationToken cancellationToken);
        Task<Domain.Entities.Homework> ExecuteGetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Domain.Entities.Homework> ExecuteUpdateAsync(Guid id, HomeworkRequest request, CancellationToken cancellationToken);
        Task<bool> ExecuteDeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
