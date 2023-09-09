using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Entity;
using Common.Extension.CQRS;
using Common.Serializers;
using FluentValidation;
using MediatR;
using MongoDB.Bson.Serialization;
using PackageDelivery.BL.Algorithms;
using PackageDelivery.BL.Extensions.Identity;
using PackageDelivery.BL.Extensions.Mapper;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
using PackageDelivery.BL.Services;
using PackageDelivery.DAL;
using PackageDelivery.DAL.Repositories;
using System.Reflection;

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

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
