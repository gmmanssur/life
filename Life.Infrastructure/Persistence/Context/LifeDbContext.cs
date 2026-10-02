using Life.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Life.Infrastructure.Persistence.Context
{
    public class LifeDbContext(DbContextOptions<LifeDbContext> options) : DbContext(options)
    {
        public DbSet<Homework> Homeworks => Set<Homework>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LifeDbContext).Assembly);

        }
    }
}
