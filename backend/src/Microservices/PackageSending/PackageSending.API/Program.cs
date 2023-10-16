using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Common.Extension.CQRS;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;
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

#region MassTransit
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});
#endregion

#region Authentication
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddAuthentication("CustomerServer")
           .AddJwtBearer("EmployeeServer", options =>
           {
               options.Authority = builder.Configuration["EmployeeIdentity:Authority"]; ;
               options.Audience = builder.Configuration["EmployeeIdentity:Audience"];
               options.RequireHttpsMetadata = false;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };

               options.Events = new JwtBearerEvents()
               {
                   OnAuthenticationFailed = (context) =>
                   {
                       context.NoResult();
                       return Task.CompletedTask;
                   }
               };

               // it's recommended to check the type header to avoid "JWT confusion" attacks
               options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
           })
           .AddJwtBearer("CustomerServer", options =>
           {
               options.Authority = builder.Configuration["CustomerIdentity:Authority"]; ;
               options.Audience = builder.Configuration["CustomerIdentity:Audience"];
               options.RequireHttpsMetadata = false;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };

               options.Events = new JwtBearerEvents()
               {
                   OnAuthenticationFailed = (context) =>
                   {
                       context.NoResult();
                       return Task.CompletedTask;
                   }
               };

               // it's recommended to check the type header to avoid "JWT confusion" attacks
               options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
           });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "customersApi", "employeeApi");
    });

    options.DefaultPolicy = options.GetPolicy("ApiScope") ?? new AuthorizationPolicyBuilder().Build();
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
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();
