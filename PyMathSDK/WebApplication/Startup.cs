using MassTransit;
using MassTransit.Eventing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebApplication;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddScoped<MassTransitEventBus>();
        services.AddTransient<IEventBus, MassTransitEventBus>();
        services.AddTransient<IMessageHandler<HelloEvent>, HelloEventHandler>();
        services.AddControllers(
            opt =>
            {
            });
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "API"
                    });
                options.CustomSchemaIds(x => x.FullName);

                var securityScheme = new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition("Bearer", securityScheme);
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        { securityScheme, Array.Empty<string>() }
                    });
            });
        services.AddMassTransitConfiguration(Configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        app.UseSwagger(
            options =>
            {
            });
        app.UseSwaggerUI();
    }
}