using FinancialAnalysis.Data;
using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

using ClosedXML.Excel;

namespace FinancialAnalysis.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly FinancialContext _context;

        public AdminController(UserManager<User> userManager, FinancialContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _context.Categories
                .Include(c => c.CategoryType)
                .ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int categoryTypeId = 1)
        {
            var model = new CreateCategoryViewModel
            {
                CategoryTypeId = categoryTypeId
            };

            var categories = await _context.CategoryTypes.ToListAsync();
            ViewBag.CategoryTypes = categories.Select(ct => new SelectListItem
            {
                Value = ct.CategoryTypeId.ToString(),
                Text = ct.TypeName
            }).ToList(); 

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = "/images/noImg.png";

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(model.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    imageUrl = $"/images/{fileName}";
                }

                var category = new Category
                {
                    Name = model.CategoryName,
                    ImageUrl = imageUrl, 
                    CategoryTypeId = model.CategoryTypeId
                };

                _context.Categories.Add(category);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Categories");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ошибка при сохранении категории. Подробности: " + ex.Message);
                }
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Ошибка валидации: {error.ErrorMessage}");
            }

            var categories = await _context.CategoryTypes.ToListAsync();
            ViewBag.CategoryTypes = categories.Select(ct => new SelectListItem
            {
                Value = ct.CategoryTypeId.ToString(),
                Text = ct.TypeName
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories
                .Include(c => c.CategoryType)
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            var model = new EditCategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.Name,
                CategoryTypeId = category.CategoryTypeId,
                CurrentImageUrl = category.ImageUrl // Сохранение текущего URL изображения
            };

            var categories = await _context.CategoryTypes.ToListAsync();
            ViewBag.CategoryTypes = categories.Select(ct => new SelectListItem
            {
                Value = ct.CategoryTypeId.ToString(),
                Text = ct.TypeName
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _context.Categories.FindAsync(model.CategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                category.Name = model.CategoryName;
                category.CategoryTypeId = model.CategoryTypeId;

                // Обработка нового файла изображения
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(model.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    category.ImageUrl = $"/images/{fileName}";
                }
                else
                {
                    // Если файл не загружен, оставляем текущее изображение
                    category.ImageUrl = model.CurrentImageUrl;
                }

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Categories");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ошибка при обновлении категории. Подробности: " + ex.Message);
                }
            }

            var categoriesList = await _context.CategoryTypes.ToListAsync();
            ViewBag.CategoryTypes = categoriesList.Select(ct => new SelectListItem
            {
                Value = ct.CategoryTypeId.ToString(),
                Text = ct.TypeName
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReport()
        {
            var users = _userManager.Users.ToList();

            var reportData = new List<UserReport>();

            foreach (var user in users)
            {
                var incomes = await _context.Incomes
                    .Where(i => i.UserId == user.Id)
                    .Include(i => i.Category)
                    .ToListAsync();

                var expenses = await _context.Expenses
                    .Where(e => e.UserId == user.Id)
                    .Include(e => e.Category)
                    .ToListAsync();

                var totalIncome = incomes.Sum(i => i.Amount);
                var totalExpense = expenses.Sum(e => e.Amount);
                var balance = totalIncome - totalExpense;

                var highestIncomeCategory = incomes
                    .GroupBy(i => i.Category != null ? i.Category.Name : "Нет категории")
                    .Select(g => new
                    {
                        Category = g.Key,
                        TotalAmount = g.Sum(i => i.Amount)
                    })
                    .OrderByDescending(g => g.TotalAmount)
                    .FirstOrDefault();

                var highestExpenseCategory = expenses
                    .GroupBy(e => e.Category != null ? e.Category.Name : "Нет категории")
                    .Select(g => new
                    {
                        Category = g.Key,
                        TotalAmount = g.Sum(e => e.Amount)
                    })
                    .OrderByDescending(g => g.TotalAmount)
                    .FirstOrDefault();

                reportData.Add(new UserReport
                {
                    UserName = user.UserName,
                    TotalIncome = totalIncome,
                    IncomeCategory = highestIncomeCategory?.Category ?? "Нет данных",
                    TotalExpense = totalExpense,
                    ExpenseCategory = highestExpenseCategory?.Category ?? "Нет данных",
                    Balance = balance
                });
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Отчет");

                worksheet.Cell(1, 1).Value = "Пользователь";
                worksheet.Cell(1, 2).Value = "Доход за всё время";
                worksheet.Cell(1, 3).Value = "Сфера наибольшего дохода";
                worksheet.Cell(1, 4).Value = "Расход за всё время";
                worksheet.Cell(1, 5).Value = "Сфера наибольшего расхода";
                worksheet.Cell(1, 6).Value = "Остаток денег";

                int row = 2;
                foreach (var data in reportData)
                {
                    worksheet.Cell(row, 1).Value = data.UserName;
                    worksheet.Cell(row, 2).Value = data.TotalIncome;
                    worksheet.Cell(row, 3).Value = data.IncomeCategory;
                    worksheet.Cell(row, 4).Value = data.TotalExpense;
                    worksheet.Cell(row, 5).Value = data.ExpenseCategory;
                    worksheet.Cell(row, 6).Value = data.Balance;
                    row++;
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "AllUsers_Report.xlsx");
                workbook.SaveAs(filePath);

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AllUsers_Report.xlsx");
            }
        }
    }
}