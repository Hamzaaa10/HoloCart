﻿using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Helpers;
using HoloCart.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace HoloCart.Infrastructure
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var externalAuthSettings = configuration.GetSection("ExternalAuthenticationSetting");

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = externalAuthSettings["GoogleClientId"];
                    googleOptions.ClientSecret = externalAuthSettings["GoogleClientSecret"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = externalAuthSettings["AppId"];
                    facebookOptions.AppSecret = externalAuthSettings["AppSecret"];
                });



            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Sign-in settings
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // User settings
                options.User.RequireUniqueEmail = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddRoleValidator<RoleValidator<ApplicationRole>>();




            //JWT Authentication
            var jwtSettings = new Jwtsettings();
            var SmtpSettings = new SmtpSettings();
            var ExternalAuthenticationSetting = new ExternalAuthenticationSetting();

            //  var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            configuration.GetSection(nameof(SmtpSettings)).Bind(SmtpSettings);
            configuration.GetSection(nameof(ExternalAuthenticationSetting)).Bind(ExternalAuthenticationSetting);

            services.AddSingleton(jwtSettings);
            services.AddSingleton(SmtpSettings);
            services.AddSingleton(ExternalAuthenticationSetting);
            services.AddHttpClient();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtSettings.ValidateIssuer,
                   ValidIssuers = new[] { jwtSettings.Issuer },
                   ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                   ValidAudience = jwtSettings.Audience,
                   ValidateAudience = jwtSettings.ValidateAudience,
                   ValidateLifetime = jwtSettings.ValidateLifeTime,
               };
           });


            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Holo ", Version = "v1" });
                //c.EnableAnnotations()

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
             {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = JwtBearerDefaults.AuthenticationScheme
                 }
             },
             Array.Empty<string>()
             }
           });
            });

            /*services.AddAuthorization(option =>
            {
                option.AddPolicy("CreateStudent", policy =>
                {
                    policy.RequireClaim("Create Student", "True");
                }
                               );
                option.AddPolicy("DeleteStudent", policy =>
                {
                    policy.RequireClaim("Delete Student", "True");
                }
                               );
                option.AddPolicy("EditStudent", policy =>
                {
                    policy.RequireClaim("Edit Student", "True");
                }
                               );
            });*/
            return services;
        }

    }
}
