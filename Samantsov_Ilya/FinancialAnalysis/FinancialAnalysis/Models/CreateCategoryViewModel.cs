using System.ComponentModel.DataAnnotations;

namespace FinancialAnalysis.Models
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Выберите тип категории")]
        public int CategoryTypeId { get; set; }

        [Required(ErrorMessage = "Введите название категории")]
        public string CategoryName { get; set; }

        public IFormFile ImageFile { get; set; } 
    }
}
