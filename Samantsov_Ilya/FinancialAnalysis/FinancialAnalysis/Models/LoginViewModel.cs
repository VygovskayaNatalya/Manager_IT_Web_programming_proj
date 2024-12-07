using System.ComponentModel.DataAnnotations;

namespace FinancialAnalysis.Models
{
    
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
