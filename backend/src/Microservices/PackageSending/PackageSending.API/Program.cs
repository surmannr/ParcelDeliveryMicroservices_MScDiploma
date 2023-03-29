using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PackageSending.BL.Extensions.CQRS;
using PackageSending.BL.Extensions.Mapper;
using PackageSending.BL.Features._Package.Queries;
using PackageSending.DAL;
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

builder.Services.AddDbContext<PackageSendingDbContext>(
    optionsBuilder => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .ReplaceService<IHistoryRepository, LoweredCaseMigrationHistoryRepository>());

#region Business logic services (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPackages).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IIdentityService, IdentityService>();
#endregion

#region Autofac Validator
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.Load("PackageSending.BL"))
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

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<PackageSendingDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
