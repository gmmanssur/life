using Life.Domain.Entities;
using Life.Infrastructure.Persistence.Repositories.Homework;

namespace Life.Application.UseCases.Homeworks.CreateHomework;

public class CreateHomeworkService(ICreateHomeworkRepository createHomeworkRepository) : ICreateHomeworkService
{
    private readonly ICreateHomeworkRepository _createHomeworkRepository = createHomeworkRepository;

    public async Task<Homework> ExecuteCreateHomeworkAsync(
        CreateHomeworkRequest request,
        CancellationToken cancellationToken)
    {
        Homework? homework = new(
            request.Title,
            request.Priority,
            request.Frequency);

        await _createHomeworkRepository.AddAsync(homework, cancellationToken);

        return homework ;
    }
}