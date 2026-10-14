using Life.Application.Commons.Interfaces.Auth;
using Life.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Life.Infrastructure.Persistence.Repositories.Auth
{
    public class AuthRepository(UserManager<ApplicationUser> userManager) : IAuthRepository
    {
        public async Task<bool> EmailExistsAsync(string email)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(email);
            return user is not null;
        }

        public async Task<CreateIdentityUserResult> CreateUserAsync(string name, string email, string password)
        {
            ApplicationUser user = new()
            {
                Name = name,
                Email = email,
                UserName = email,
                IsActive = true
            };

            IdentityResult result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return new CreateIdentityUserResult(false, null, [.. result.Errors.Select(error => error.Description)]);
            }

            return new CreateIdentityUserResult(true, user.Id, []);
        }
    }
}
