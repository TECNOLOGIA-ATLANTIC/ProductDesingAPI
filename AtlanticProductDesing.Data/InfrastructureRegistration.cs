using AtlanticProductDesing.Application.Contracts.Infrastructure;
using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Application.Models;
using AtlanticProductDesing.Infrastruture.CurentUser;
using AtlanticProductDesing.Infrastruture.Email;
using AtlanticProductDesing.Infrastruture.Persistence;
using AtlanticProductDesing.Infrastruture.Repositories;
using AtlanticProductDesing.Infrastruture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AtlanticProductDesing.Infrastruture
{
    /// <summary>
    /// Clase para registrar la inyección de dependencias de Infrastructure
    /// </summary>
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")).EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Scoped);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICurrentUserService, CurrentUserApiService>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));


            // Registro de repositorios para las entidades de la academia



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileSystemService, FileSystemService>();

            services.AddHttpClient();

            return services;
        }

        // Método para aplicar migraciones
        public static async Task ApplyMigrationsApplicationAsync(this IServiceProvider services)
        {

            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
        }

        // Método para ejecutar seeders
        public static async Task SeedDataAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.SeedDataAsync(); // Asegúrate de implementar este método en ApplicationDbContext
        }
    }
}
