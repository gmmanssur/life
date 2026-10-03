using Life.Infrastructure.Persistence.Context;

namespace Life.Infrastructure.Persistence.Repositories.Homework.Create
{
    public class CreateHomeworkRepository(LifeDbContext context) : ICreateHomeworkRepository
    {
        private readonly LifeDbContext _context = context;

        public async Task AddAsync(
            Domain.Entities.Homework? homework,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(homework);

            await _context.Homeworks.AddAsync(homework, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
