using Life.Infrastructure.Persistence.Context;
using Life.Infrastructure.Persistence.Repositories.Homework;
using Life.Infrastructure.Persistence.Repositories.Homework.Create;
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

            //addscope for repositoriesand interfaceshere
            services.AddScoped<ICreateHomeworkRepository, CreateHomeworkRepository>();

            return services;
        }
    }
}
