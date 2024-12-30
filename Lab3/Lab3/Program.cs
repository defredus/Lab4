using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab3.DBContext;
using Lab3.Models;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Загрузка конфигурации
            var configuration = builder.Configuration;
            builder.Services.AddControllersWithViews();

            // Подключение BLL
            var connectionString = configuration.GetConnectionString("SQL");
            builder.Services.ConfigureBLL(connectionString);

            // Подключение контекста базы данных
            builder.Services.AddDbContext<AccountDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Настройка Identity
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AccountDbContext>()
            .AddDefaultTokenProviders();

            // Добавление политик авторизации
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ModeratorPolicy", policy => policy.RequireRole("Moderator"));
				options.AddPolicy("JournalistPolicy", policy => policy.RequireRole("Journalist"));
				options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });

            var app = builder.Build();

            // Инициализация базы данных
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AccountDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                DBInitializer.InitializeAsync(dbContext, userManager, roleManager).Wait();
            }

            // Настройка HTTP-конвейера
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Добавлено использование аутентификации
            app.UseAuthorization();

            // Настройка маршрутов
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
