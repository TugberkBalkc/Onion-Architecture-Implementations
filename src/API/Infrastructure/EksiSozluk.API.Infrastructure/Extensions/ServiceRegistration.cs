using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Interfaces.Handlers.Token;
using EksiSozluk.API.Application.Interfaces.Services;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using EksiSozluk.API.Infrastructure.Handlers.Token.JsonWebToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticationService,EksiSozluk.API.Infrastructure.Services.AuthenticationService>();
            services.AddScoped<ITokenHandler, JwtTokenHandler>();

            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services
              .AddAuthentication(config =>
              {
                  config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = tokenOptions.Issuer,
                      ValidAudience = tokenOptions.Audience,
                      IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                  };
              });

            return services;
        }
    }
}
