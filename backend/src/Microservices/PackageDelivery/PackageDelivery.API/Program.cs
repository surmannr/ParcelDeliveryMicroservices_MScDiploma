using Autofac;
using Autofac.Extensions.DependencyInjection;
using PackageDelivery.BL.Extensions.Identity;
using PackageDelivery.BL.Extensions.Mapper;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
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
builder.Services.AddScoped<IVehicleUsageRepository, VehicleUsageRepository>();
#endregion

#region Business logic services (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllVehicleUsages).Assembly));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IIdentityService, IdentityService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
