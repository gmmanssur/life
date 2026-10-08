using Life.Application.Commons.Interfaces.Homework;
using Life.Domain.Entities;

namespace Life.Application.UseCases.Homeworks
{
    public class HomeworkService(IHomeworkRepository homeworkRepository) : IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository = homeworkRepository;

        public async Task<Homework> ExecuteCreateAsync(HomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework homework = new(
                request.Title,
                request.Priority,
                request.Frequency);

            await _homeworkRepository.AddAsync(homework, cancellationToken);

            return homework;
        }

        public async Task<List<Homework>> ExecuteGetAllAsync(CancellationToken cancellationToken)
             => await _homeworkRepository.GetAllAsync(cancellationToken) ?? throw new KeyNotFoundException("Homework not found.");

        public async Task<Homework> ExecuteGetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _homeworkRepository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Homework not found.");

        public async Task<Homework> ExecuteUpdateAsync(Guid id, HomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework homework = await _homeworkRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException("Homework not found.");

            homework.Update(
                request.Title,
                request.Priority,
                request.Frequency);

            await _homeworkRepository.UpdateAsync(homework, cancellationToken);

            return homework;
        }

        public async Task<bool> ExecuteDeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            Homework homework = await _homeworkRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException("Homework not found.");

            await _homeworkRepository.DeleteAsync(homework, cancellationToken);

            return true;
        }
    }
}
