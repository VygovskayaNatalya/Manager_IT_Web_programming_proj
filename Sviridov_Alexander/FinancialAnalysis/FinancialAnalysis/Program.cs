using FinancialAnalysis.Data;
using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавление контекста базы данных
builder.Services.AddDbContext<FinancialContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FinancialContext>()
    .AddDefaultTokenProviders();

// Добавление служб для MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<FinancialContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        Console.WriteLine("Инициализация базы данных...");
        await FinancialDbInitializer.Initialize(context, userManager); // Добавьте await здесь
        Console.WriteLine("Инициализация завершена.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка инициализации базы данных: {ex.Message}");
}

// Настройка маршрутизации
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Запуск приложения
app.Run();
