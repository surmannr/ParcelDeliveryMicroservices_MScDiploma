using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

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

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true).AddEnvironmentVariables();
});

builder.Host.ConfigureLogging((hostingContext, loggingBuilder) =>
{
    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var customerProviderKey = "CustomerServer";
var employeeProviderKey = "EmployeeServer";

builder.Services.AddAuthentication(customerProviderKey)
    .AddJwtBearer(employeeProviderKey, options =>
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
    .AddJwtBearer(customerProviderKey, options =>
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

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();
