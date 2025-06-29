using AtlanticProductDesing.Application.Behaviours;
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Application.Factories;
using AtlanticProductDesing.Application.Services;
using AtlanticProductDesing.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AtlanticProductDesing.Aplication
{
    /// <summary>
    /// clase para registrar la inyección de dependecia de aplicationService
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandlreExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            // services.AddScoped<ITokenCommons, TokenCommons>();
            services.AddScoped<IEmailDoncFactory, EmailDoncFactory>();



            // Registro de servicios y repositorios para las entidades de la academia

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBaseService<Person>, PersonService>();



            return services;
        }
    }
}
