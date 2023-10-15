using Employees.API;
using Employees.API.Data;
using Employees.API.EventBusConsumer;
using Employees.API.Mapper;
using Employees.API.Models;
using EventBus.Messages.Common;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddScoped<IUserClaimsPrincipalFactory<Employee>, MyClaimsPrincipalFactory>();
    builder.Services.AddScoped<IClaimsTransformation, MyClaimTransformation>();

    #region CORS policy
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader());
    });
    #endregion

    #region Automapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    #endregion

    #region MassTransit
    builder.Services.AddMassTransit(config =>
    {
        config.AddConsumer<AlgorithmExecutedConsumer>();
        config.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

            cfg.ReceiveEndpoint(EventBusConstants.AlgorithmExecutedQueue, c =>
            {
                c.ConfigureConsumer<AlgorithmExecutedConsumer>(ctx);
            });
        });
    });
    #endregion

    #region Consumers 
    builder.Services.AddScoped<AlgorithmExecutedConsumer>();
    #endregion

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<EmployeesDbContext>();
        dataContext.Database.Migrate();
    }

    // this seeding is only for the template to bootstrap the DB and users.
    // in production you will likely want a different approach.
    Log.Information("Seeding database...");
    SeedData.EnsureSeedData(app);
    Log.Information("Done seeding database. Exiting.");
    
    app.UseCors("CorsPolicy");

    app.MapControllers();

    app.Run();
}
catch (Exception ex) when (ex.GetType().Name is not "StopTheHostException") // https://github.com/dotnet/runtime/issues/60600
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}