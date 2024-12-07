using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinancialAnalysis.Models
{
    public class User : IdentityUser
    {
        public UserRole Role { get; set; } 
        public List<Income> Incomes { get; set; } 
        public List<Expense> Expenses { get; set; } 
    }
}