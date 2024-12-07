namespace FinancialAnalysis.Models
{
    public class UserReport
    {
        public string UserName { get; set; }
        public decimal TotalIncome { get; set; }
        public string IncomeCategory { get; set; }
        public decimal TotalExpense { get; set; }
        public string ExpenseCategory { get; set; }
        public decimal Balance { get; set; }
    }
}
