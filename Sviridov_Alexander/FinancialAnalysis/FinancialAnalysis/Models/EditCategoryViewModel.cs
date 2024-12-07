using System.ComponentModel.DataAnnotations;

namespace FinancialAnalysis.Models
{
    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; } // Идентификатор категории

        [Required(ErrorMessage = "Выберите тип категории")]
        public int CategoryTypeId { get; set; } // Тип категории, обязательное поле

        [Required(ErrorMessage = "Введите название категории")]
        public string CategoryName { get; set; } // Название категории, обязательное поле

        public string CurrentImageUrl { get; set; } // URL текущего изображения

        public IFormFile? ImageFile { get; set; } // Файл для загрузки нового изображения
    }
}
