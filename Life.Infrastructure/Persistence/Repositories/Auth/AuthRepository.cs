using Life.Application.Commons.Interfaces.Auth;
using Life.Application.UseCases.Auth.Login;
using Life.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Life.Infrastructure.Persistence.Repositories.Auth
{
    public class AuthRepository(UserManager<ApplicationUser> userManager) : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<bool> EmailExistsAsync(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);
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

            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return new CreateIdentityUserResult(false, null, [.. result.Errors.Select(error => error.Description)]);

            return new CreateIdentityUserResult(true, user.Id, []);
        }

        public async Task<AuthenticatedUser?> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, password))
                return null;

            return new AuthenticatedUser(user.Id, user.Name, user.Email ?? string.Empty);
        }   
    }
}
