using Life.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Life.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("users");

            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.CreatedAt)
                .IsRequired();

            builder.Property(user => user.IsActive)
                .IsRequired();
        }
    }
}