using AtlanticProductDesing.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AtlanticProductDesing.API.Extensions
{
    public static class MigrationsExtension
    {
        public static async void RunMigrations(this WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                IMediator mediator = scope.ServiceProvider.GetService<IMediator>();
                IHostEnvironment environment = scope.ServiceProvider.GetService<IHostEnvironment>();
                try
                {

                    var context = services.GetRequiredService<ApplicationDbContext>();
                    //var contextIdentity = services.GetRequiredService<IdentityDbContext>();
                    //var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    IConfiguration configuration = scope.ServiceProvider.GetService<IConfiguration>();

                    // await contextIdentity.Database.MigrateAsync();
                    await context.Database.MigrateAsync();


                    //await EventusDbContextSeed.SeedAsync(context, loggerFactory);
                    //  await EventusDbContextSeedData.LoadDataAsyn(context, loggerFactory, configuration, mediator, environment);

                    //  await EventusIdentityDbContextSeedData.LoadDataAsyn(contextIdentity, _userManager, loggerFactory, configuration);

                }
                catch (Exception ex)
                {

                    Logger logger = LogManager.GetCurrentClassLogger();
                    logger.Error(ex, "Error migrations");

                }

            }
        }
    }
}
