using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Notes.Application.ExternalLogic;
using System.Text;

namespace Notes.WebApi.Extentions
{
    public static class ApiExtentions
    {
        public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                context.Token = context.Request.Cookies["notJwtToken"];
                                return Task.CompletedTask;
                            }
                        };
                    });

            services.AddAuthorization();
        }
    }
}
