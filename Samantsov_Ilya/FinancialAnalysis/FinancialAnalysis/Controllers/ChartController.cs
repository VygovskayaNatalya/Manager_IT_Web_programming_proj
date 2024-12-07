using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialAnalysis.Models;
using System.Linq;
using System.Threading.Tasks;
using FinancialAnalysis.Data;

namespace FinancialAnalysis.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly FinancialContext _context;

        public ChartController(UserManager<User> userManager, FinancialContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> IncomeChart()
        {
            var user = await _userManager.GetUserAsync(User);

            var incomes = await _context.Incomes
                .Where(i => i.UserId == user.Id)
                .Include(i => i.Category)
                .ToListAsync();

            var model = new ChartViewModel
            {
                Incomes = incomes
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ExpenceChart()
        {
            var user = await _userManager.GetUserAsync(User);

            var expenses = await _context.Expenses
                .Where(e => e.UserId == user.Id)
                .Include(e => e.Category)
                .ToListAsync();

            var model = new ChartViewModel
            {
                Expenses = expenses
            };

            return View(model);
        }
    }
}