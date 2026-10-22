using Life.Application.Commons.Interfaces.Auth;
using Life.Application.Commons.Interfaces.Homework;
using Life.Infrastructure.Identity;
using Life.Infrastructure.Persistence.Context;
using Life.Infrastructure.Persistence.Repositories.Auth;
using Life.Infrastructure.Persistence.Repositories.Homework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<LifeDbContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<LifeDbContext>();

            services.AddScoped<IHomeworkRepository, HomeworkRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITokenProvider, TokenProvider>();

            return services;
        }
    }
}
