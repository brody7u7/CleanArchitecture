using $ext_safeprojectname$.API.Services;
using $ext_safeprojectname$.Core.Interfaces;
using $ext_safeprojectname$.Core.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace $ext_safeprojectname$.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.Configure<Core.Configuration.ApiSettings>(configuration);
            services.Configure<Core.Configuration.JwtSettings>(configuration.GetSection("Jwt"));

            services.AddSingleton<ITokenClaimsService, JwtHelper>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            // Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                });

            // Authorization policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Administrator,
                    policy => policy.RequireRole(Roles.Administrator));
            });

            // Cors policy
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            // Swagger doc
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Clean Architecture API",
                    Version = "v1",
                    Description = "API for internal platform administration",
                    Contact = new OpenApiContact
                    {
                        Url = new Uri("https://softwareup.dev/")
                    }
                });

                var securityScheme = new OpenApiSecurityScheme()
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Token ** ONLY **",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });



            return services;
        }
    }
}
