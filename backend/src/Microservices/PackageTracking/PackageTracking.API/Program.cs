using EventBus.Messages.Common;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
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

#region Authentication
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.Authority = builder.Configuration["CustomerIdentity:Authority"]; ;
               options.Audience = builder.Configuration["CustomerIdentity:Audience"];
               options.RequireHttpsMetadata = false;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };

               // it's recommended to check the type header to avoid "JWT confusion" attacks
               options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
           });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "customersApi");
    });

    options.DefaultPolicy = options.GetPolicy("ApiScope") ?? new AuthorizationPolicyBuilder().Build();
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

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();
