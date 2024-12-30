using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Проверьте логин")]
        [Display(Name = "Логин")]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Display(Name = "Оставаться в сети")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
