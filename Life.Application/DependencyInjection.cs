using Life.Application.Commons.Interfaces.Auth.Login;
using Life.Application.Commons.Interfaces.Auth.Register;
using Life.Application.Commons.Interfaces.Homework;
using Life.Application.UseCases.Auth.Login;
using Life.Application.UseCases.Auth.Register;
using Life.Application.UseCases.Homeworks;
using Microsoft.Extensions.DependencyInjection;
using Life.Application.UseCases.Auth.Register.Validator;
using FluentValidation;

namespace Life.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHomeworkService, HomeworkService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

            return services;
        }
    }
}