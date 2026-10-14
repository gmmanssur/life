using Microsoft.AspNetCore.Identity;

namespace Life.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}