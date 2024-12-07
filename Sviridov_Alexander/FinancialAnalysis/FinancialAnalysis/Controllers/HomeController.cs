using Microsoft.AspNetCore.Mvc;
using FinancialAnalysis.Data;
using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace FinancialAnalysis.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinancialContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(FinancialContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User); 

            var incomes = await _context.Incomes
                .Where(i => i.UserId == user.Id) 
                .Include(i => i.Category) 
                .ToListAsync();

            var expenses = await _context.Expenses
                .Where(e => e.UserId == user.Id) 
                .Include(e => e.Category) 
                .ToListAsync();

            var viewModel = new HomeViewModel
            {
                Incomes = incomes,
                Expenses = expenses
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteIncome(int id)
        {
            var income = _context.Incomes.Find(id);
            if (income != null && income.UserId == _userManager.GetUserId(User)) 
            {
                _context.Incomes.Remove(income);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new CreateTransactionViewModel
            {
                IncomeCategories = _context.Categories
                    .Where(c => c.CategoryType.TypeName == "Доход")
                    .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name })
                    .ToList(),
                ExpenseCategories = _context.Categories
                    .Where(c => c.CategoryType.TypeName == "Расход")
                    .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransactionViewModel model)
        {
            if(model.Description == null)
            {
                model.Description = " ";
            }

            var user = await _userManager.GetUserAsync(User);
            if (model.IsIncome)
            {
                var income = new Income
                {
                    Amount = model.Amount,
                    Date = model.Date,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    UserId = user.Id
                };
                _context.Incomes.Add(income);
            }
            else
            {
                var expense = new Expense
                {
                    Amount = model.Amount,
                    Date = model.Date,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    UserId = user.Id
                };
                _context.Expenses.Add(expense);
            }

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка при сохранении данных в базе.");
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }

            return View(model);
        }
    }
}