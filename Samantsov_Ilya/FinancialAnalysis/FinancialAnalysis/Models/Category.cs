namespace FinancialAnalysis.Models
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public string Name { get; set; } 
        public string ImageUrl { get; set; } 
        public int CategoryTypeId { get; set; } 
        public CategoryType CategoryType { get; set; } 
        public List<Income> Incomes { get; set; } 
        public List<Expense> Expenses { get; set; } 
    }
}
