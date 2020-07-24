using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace ResourceManagement.Middleware
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var secret = config.GetSection("Jwt").GetSection("Key").Value;

            var key = Encoding.ASCII.GetBytes(secret);
            //services.AddAuthentication(x =>
            //{
            //    //x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //IssuerSigningKey = new SymmetricSecurityKey(key),
            //        //ValidateIssuer = false,
            //        //ValidateAudience = false,
            //        // ValidIssuer = "localhost",
            //        //ValidAudience = "localhost"

            //        //config.GetSection("Jwt").GetSection("Issuer").Value; config.GetSection("Jwt").GetSection("Issuer").Value;
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = config["Jwt:Issuer"],
            //        ValidAudience = config["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
            //    };
            //});

            return services;
        }
    }
}
