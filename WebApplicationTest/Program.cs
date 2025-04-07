using Domain.Repositories;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.JWT;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Text;

namespace WebApplicationTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var service = builder.Services;

            service.Configure<JWTOptions>(configuration.GetSection("JwtOptions")); // Подключение конфигураций jwt токенов
            service.AddApiAuthentication(configuration);

            // Подключения Swagger
            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            // Подключение к базе данных PostgreSQL
            builder.Services.AddDbContext<AppDBContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")); // Данные для подключения к бд берутся из appsettings.json
                }
            
                );

            // Подключение репозиториев и сервисов
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IHasherRepository, PasswordHasherRepository>();
            builder.Services.AddScoped<IJWTProviderRepository, JWTProvider>();
            builder.Services.AddScoped<ClientService>();
            builder.Services.AddScoped<ItemService>();
            builder.Services.AddScoped<SMSService>();
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (builder.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            // Страница являющаяся точкой входа
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Start}/{action=Auth}/{id?}");

            app.Run();
        }
    }
}
