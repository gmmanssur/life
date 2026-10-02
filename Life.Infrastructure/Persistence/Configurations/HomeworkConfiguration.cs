using Life.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Life.Infrastructure.Persistence.Configurations;

public sealed class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.ToTable("homeworks");

        builder.HasKey(homework => homework.Id);

        builder.Property(homework => homework.Id)
            .ValueGeneratedNever();

        builder.Property(homework => homework.Description)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(homework => homework.Priority)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(homework => homework.Frequency)
            .IsRequired()
            .HasConversion<string>();
    }
}