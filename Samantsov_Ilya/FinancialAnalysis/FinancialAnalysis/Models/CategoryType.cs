namespace FinancialAnalysis.Models
{
    public class CategoryType
    {
        public int CategoryTypeId { get; set; } 
        public string TypeName { get; set; } 
        public List<Category> Categories { get; set; } 
    }
}
