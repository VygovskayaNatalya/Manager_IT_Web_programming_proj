using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialAnalysis.Models
{
    public class CreateTransactionViewModel
    {
        public bool IsIncome { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; } 
        public string Description { get; set; } 
        public DateTime Date { get; set; } 

        public List<SelectListItem> IncomeCategories { get; set; } 
        public List<SelectListItem> ExpenseCategories { get; set; } 
    }
}