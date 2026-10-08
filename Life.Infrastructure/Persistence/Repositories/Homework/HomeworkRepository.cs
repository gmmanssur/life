using Life.Application.Commons.Interfaces.Homework;
using Life.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Life.Infrastructure.Persistence.Repositories.Homework
{
    public class HomeworkRepository(LifeDbContext context) : IHomeworkRepository
    {
        private readonly LifeDbContext _context = context;

        public async Task AddAsync(Domain.Entities.Homework? homework, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(homework);

            await _context.Homeworks.AddAsync(homework, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Domain.Entities.Homework>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Homeworks
                .ToListAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Homework?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Homeworks
                .Where(h => h.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Homework> UpdateAsync(Domain.Entities.Homework homework, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);

            return homework;
        }

        public async Task DeleteAsync(Domain.Entities.Homework homework, CancellationToken cancellationToken)
        {
            _context.Homeworks.Remove(homework);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
