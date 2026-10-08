using Life.Application.Commons.Interfaces.Homework;
using Life.Application.UseCases.Homeworks;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHomeworkService, HomeworkService>();

            return services;
        }
    }
}