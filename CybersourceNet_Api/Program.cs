using CybersourceNet_Api.Validators;
using CybersourceNet_App.ViewModels.Auth;
using CybersourceNet_App.ViewModels.Request;
using CybersourceNet_Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CybersourceNet_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddConfigurations(builder.Configuration);
            builder.Services.AddIoC();
            builder.Services.AddErrorHandler(builder.Environment);
            builder.Services.AddLogging<LoggingService>();
            //builder.Services.AddControllers();
            builder.Services.AddControllersWithValidations(validator =>
             {
                 validator.AddValidator<PaymentRequestViewModel, PaymentRequestValidator>();
                 validator.AddValidator<CaptureRequestViewModel, CaptureRequestValidator>();
                 validator.AddValidator<ReversalRequestViewModel, ReversalRequestValidator>();
                 validator.AddValidator<UserLoginRequestViewModel, UserLoginRequestValidator>();
             });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["JwtConfig:Audience"],
                    ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CybersourceNet",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseLoggingMiddleware();

            app.UseErrorMiddleware(app.Environment);

            app.MapControllers();

            app.Run();
        }
    }
}