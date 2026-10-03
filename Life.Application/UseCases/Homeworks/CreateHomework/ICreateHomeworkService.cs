using Life.Domain.Entities;

namespace Life.Application.UseCases.Homeworks.CreateHomework
{
    public interface ICreateHomeworkService
    {
        Task<Homework> ExecuteCreateHomeworkAsync(CreateHomeworkRequest request, CancellationToken cancellationToken);
    }
}
