using Life.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString(
                    "DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString));

            //addscope for repositoriesand interfaceshere

            return services;
        }
    }
}
