using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Common.Entity;
using Common.Extension.CQRS;
using Common.Serializers;
using EventBus.Messages.Common;
using FluentValidation;
using Hangfire;
using Hangfire.SqlServer;
using MassTransit;
using MediatR;
using System.Data.SqlClient;
using PackageDelivery.API;
using PackageDelivery.API.EventBusConsumer;
using PackageDelivery.BL.Algorithms;
using PackageDelivery.BL.Extensions.Identity;
using PackageDelivery.BL.Extensions.Mapper;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
using PackageDelivery.BL.Services;
using PackageDelivery.DAL;
using PackageDelivery.DAL.Repositories;
using System.Reflection;
using MongoDB.Driver.Core.Configuration;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

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

using (var conn = new SqlConnection(builder.Configuration.GetConnectionString("HangfireConnectionCreateDb")))
{
    conn.Open();
    string commandtext = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ParcelDelivery_SchedulerDb')\r\nBEGIN\r\n  CREATE DATABASE ParcelDelivery_SchedulerDb;\r\nEND;\r\n";

    var cmd = new SqlCommand(commandtext, conn);

    var reader = cmd.ExecuteReader();
}

#region Hangfire
builder.Services.AddHangfire(configuration => configuration
       .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
       .UseSimpleAssemblyNameTypeSerializer()
       .UseRecommendedSerializerSettings()
       .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
       {
           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
           QueuePollInterval = TimeSpan.Zero,
           UseRecommendedIsolationLevel = true,
           DisableGlobalLocks = true
       }));

builder.Services.AddHangfireServer(options =>
{
    options.Queues = new[] {
                    "algorithm",
                    "default" };
});

builder.Services.AddHangfireServer();
#endregion

#region Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion

#region DAL
builder.Services.AddScoped<IPackageDeliveryContext, PackageDeliveryContext>();
builder.Services.AddScoped<IAcceptedShippingRequestRepository, AcceptedShippingRequestRepository>();
builder.Services.AddScoped<IShippingRequestRepository, ShippingRequestRepository>();
builder.Services.AddScoped<IVehicleUsageRepository, VehicleUsageRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
#endregion

#region Business logic services (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllVehicleUsages).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IIdentityService, IdentityService>();
#endregion

#region Services
builder.Services.AddScoped<IParcelPackingAlgorithm, ParcelPackingAlgorithm>();
builder.Services.AddScoped<ISchedulingService, SchedulingService>();
#endregion

#region Autofac Validator
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.Load("PackageDelivery.BL"))
        .Where(x => x.Name.EndsWith("Validator"))
        .AsImplementedInterfaces()
        .InstancePerDependency();

});
#endregion

#region MassTransit
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<AssignEmployeesConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.AssignEmployeesQueue, c =>
        {
            c.ConfigureConsumer<AssignEmployeesConsumer>(ctx);
        });
    });
});
#endregion

#region Consumers 
builder.Services.AddScoped<AssignEmployeesConsumer>();
#endregion

//BsonSerializer.RegisterSerializer(typeof(Address), new AddressSerializer());
//BsonSerializer.RegisterSerializer(typeof(PaymentOption), new PaymentOptionSerializer());
//BsonSerializer.RegisterSerializer(typeof(ShippingOption), new ShippingOptionSerializer());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});
RecurringJob.AddOrUpdate<ISchedulingService>((schedulingService) => schedulingService.Schedule(), Cron.Daily, queue: "algorithm");

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
