using CarApp.Business;
using CarApp.Business.Entities;
using CarApp.Business.Interfaces;
using CarApp.DataAccess;
using CarApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Startup
{
    public static class Startup
    {
        public static void RegisterServices(this WebApplicationBuilder builder)

        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.ConfigureCors();

            builder.Services.AddSwaggerGen();

            builder.RegisterAppSettings();
            builder.ConfigureAppSettings();

            builder.Services.AddScoped<CarHandler, CarHandler>();
            builder.Services.AddScoped<IRepository<Car>, CarRepository>();
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserHandler, UserHandler>();
        }

        private static void ConfigureAppSettings(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("CarAppDb");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        private static void RegisterAppSettings(this WebApplicationBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            builder.Services.AddSingleton(configuration);
        }

        private static void ConfigureCors(this WebApplicationBuilder builder)
        {
            var frontendAppUrl = builder.Configuration.GetSection("FrontendApp:Url");

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                                          policy =>
                                          {
                                              policy.WithOrigins(frontendAppUrl.Value)
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .AllowCredentials();
                                          });
            });
        }

        public static void ConfigureApp(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
