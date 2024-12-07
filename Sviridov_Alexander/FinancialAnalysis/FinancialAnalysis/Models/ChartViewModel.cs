using System.Collections.Generic;

namespace FinancialAnalysis.Models
{
    public class ChartViewModel
    {
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}