using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManagement.Repository.Contract;
using ResourceManagement.Repository.Methods;
using ResourceManagement.Service.Contract;
using ResourceManagement.Service.Methods;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Hosting;
//using ResourceManagement.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace ResourceManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
            services.AddCors();
            services.Configure<ReadConfig>(Configuration.GetSection("ConnectionString"));
            services.AddControllers();
            //services.AddTokenAuthentication(Configuration);
            //services.AddMvcCore();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                 };
                 options.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             });

            var mapConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfigProfile());
            });
            var mapper = mapConfig.CreateMapper();
            services.AddScoped<ILoginService,LoginService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(mapper);
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("ResourceAllotApi", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Resource Allocation API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //option.IncludeXmlComments(xmlPath);
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseAuthorization();
           
            //app.UseAuthentication();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/ResourceAllotApi/swagger.json", "ResourceAllot API");
                 
            });
            app.UseStaticFiles();
            app.UseCors();
            //app.UseCors();

            app.UseCors(p => p.WithOrigins("http://localhost:5000"));
            //              .WithMethods("GET")
            //              .WithHeaders("name"));
            //app.UseMvc();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

    }
}
