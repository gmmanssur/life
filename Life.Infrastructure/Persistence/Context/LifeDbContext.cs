using Life.Domain.Entities;
using Life.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Life.Infrastructure.Persistence.Context
{
    public class LifeDbContext(DbContextOptions<LifeDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Homework> Homeworks => Set<Homework>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(LifeDbContext).Assembly);
        }
    }
}
