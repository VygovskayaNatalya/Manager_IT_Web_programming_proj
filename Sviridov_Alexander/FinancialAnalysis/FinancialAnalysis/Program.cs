using FinancialAnalysis.Data;
using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ���������� ��������� ���� ������
builder.Services.AddDbContext<FinancialContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FinancialContext>()
    .AddDefaultTokenProviders();

// ���������� ����� ��� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<FinancialContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        Console.WriteLine("������������� ���� ������...");
        await FinancialDbInitializer.Initialize(context, userManager); // �������� await �����
        Console.WriteLine("������������� ���������.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"������ ������������� ���� ������: {ex.Message}");
}

// ��������� �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// ������ ����������
app.Run();
