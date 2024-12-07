using System;
using System.Linq;
using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinancialAnalysis.Data
{
    public class FinancialDbInitializer
    {
        public static async Task Initialize(FinancialContext context, UserManager<User> userManager)
        {
            await context.Database.EnsureCreatedAsync();

            if (await context.Users.AnyAsync())
            {
                return; 
            }

            var categoryTypes = new CategoryType[]
            {
        new CategoryType { TypeName = "Доход" },
        new CategoryType { TypeName = "Расход" }
            };
            await context.CategoryTypes.AddRangeAsync(categoryTypes);
            await context.SaveChangesAsync();

            var categories = new Category[]
            {
        new Category { Name = "Зарплата", ImageUrl = "/images/salary.png", CategoryTypeId = 1 },
        new Category { Name = "Инвестиции", ImageUrl = "/images/investment.png", CategoryTypeId = 1 },
        new Category { Name = "Продукты", ImageUrl = "/images/groceries.png", CategoryTypeId = 2 },
        new Category { Name = "Транспорт", ImageUrl = "/images/transport.png", CategoryTypeId = 2 },
        new Category { Name = "Развлечения", ImageUrl = "/images/entertainment.png", CategoryTypeId = 2 }
            };
            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var users = new User[]
            {
        new User { UserName = "admin", Email = "admin@example.com", Role = UserRole.Admin },
        new User { UserName = "client1", Email = "client1@example.com", Role = UserRole.Client }
            };

            foreach (var user in users)
            {
                string password = "Password123!";
                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception($"Не удалось создать пользователя {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            await context.SaveChangesAsync();

            var incomes = new Income[]
            {
        new Income { Amount = 5000, Date = new DateTime(2024, 1, 15), Description = "", CategoryId = 1, UserId = users[1].Id },
        new Income { Amount = 1500, Date = new DateTime(2024, 1, 20), Description = "Акции от Apple", CategoryId = 2, UserId = users[1].Id }
            };
            await context.Incomes.AddRangeAsync(incomes);
            await context.SaveChangesAsync();

            var expenses = new Expense[]
            {
        new Expense { Amount = 200, Date = new DateTime(2024, 1, 22), Description = "Купил сметану", CategoryId = 3, UserId = users[1].Id },
        new Expense { Amount = 100, Date = new DateTime(2024, 1, 23), Description = "Поехал на маршрутке", CategoryId = 4, UserId = users[1].Id },
        new Expense { Amount = 300, Date = new DateTime(2024, 1, 25), Description = "Кино", CategoryId = 5, UserId = users[1].Id }
            };
            await context.Expenses.AddRangeAsync(expenses);
            await context.SaveChangesAsync();
        }
    }
}