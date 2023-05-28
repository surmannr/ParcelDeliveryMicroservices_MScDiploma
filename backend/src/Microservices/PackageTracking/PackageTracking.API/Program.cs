using EventBus.Messages.Common;
using MassTransit;
using PackageTracking.API.EventBusConsumer;
using PackageTracking.API.Mapper;
using PackageTracking.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["CacheSettings:ConnectionString"];
});

builder.Services.AddScoped<IPackageTrackingRepository, PackageTrackingRepository>();

#region Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion

#region MassTransit
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<SendingPackageConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.SendingPackageQueue, c =>
        {
            c.ConfigureConsumer<SendingPackageConsumer>(ctx);
        });
    });
});
#endregion

#region Consumers 
builder.Services.AddScoped<SendingPackageConsumer>();
#endregion

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

app.UseAuthorization();

app.MapControllers();

app.Run();
