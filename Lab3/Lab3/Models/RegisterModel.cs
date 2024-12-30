using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class RegisterModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Не верный пароль. Повторите еще раз.")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Имя не верно")]
        public string? LastName { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
