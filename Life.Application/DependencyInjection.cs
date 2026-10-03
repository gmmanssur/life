using Life.Application.UseCases.Homeworks.CreateHomework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateHomeworkService, CreateHomeworkService>();

            return services;
        }
    }
}