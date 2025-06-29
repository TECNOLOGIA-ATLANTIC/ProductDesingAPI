using AtlanticProductDesing.API.Middleware;

using AtlanticProductDesing.Aplication;
using AtlanticProductDesing.Domain;
using AtlanticProductDesing.Infrastruture;
using System.Reflection;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.AddConsole();
    builder.Logging.AddEventLog();
    // Add services to the container.

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddControllers();
    //.AddJsonOptions(options =>
    //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddApplicationServices();
    builder.Services.AddDomainServices(builder.Configuration);

    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

    // builder.Services.ConfigureIdentityServices(builder.Configuration);



    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => builder
           //.SetIsOriginAllowed(origin => true)  // Reemplaza con la URL de tu aplicación Angular
           .WithOrigins(allowedOrigins)
            //.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
    });

    builder.Services.AddDataProtection();


    builder.Services.AddSignalR(hubOptions =>
    {
        hubOptions.EnableDetailedErrors = true;
        hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(10);
        hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(5);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    //app.RunMigrations();

    // Aplicar migraciones y ejecutar seeders
    try
    {
        // await app.Services.ApplyMigrationsIdentityAsync();
        await app.Services.ApplyMigrationsApplicationAsync();

        await app.Services.SeedDataAsync();
    }
    catch (Exception ex)
    {
        // Manejo de errores
        Console.WriteLine($"Error applying migrations or seeding data: {ex.Message}");
        // Dependiendo del caso, podrías decidir si detener la aplicación o continuar
    }

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseMiddleware<MyInterceptor>();

    app.UseAuthentication();


    app.UseAuthorization();

    app.UseCors("CorsPolicy");

    app.MapControllers();
    //app.MapHub<CompetitionHub>("/competitionHub");

    app.Run();
}
catch (AggregateException ex)
{
    foreach (var innerException in ex.InnerExceptions)
    {
        Console.WriteLine(innerException.Message);
    }
    throw;
}
