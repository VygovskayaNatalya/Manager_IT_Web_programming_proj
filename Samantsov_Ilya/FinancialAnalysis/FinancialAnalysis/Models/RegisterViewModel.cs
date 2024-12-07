using System.ComponentModel.DataAnnotations;

namespace FinancialAnalysis.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя пользователя.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} и не более {1} символов.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,100}$", ErrorMessage = "Пароль должен содержать как минимум одну строчную букву, одну заглавную букву, одну цифру и один специальный символ.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}