using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.DTO
{
    public class RegistrationModel
    {
		[Required(ErrorMessage = "Ім'я обов'язкове")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email обов'язковий")]
		[EmailAddress]
        public string Email { get; set; }

		[Required(ErrorMessage = "Логін обов'язковий")]
		public string Username { get; set; }

        [Required]
       [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage =
"Мінімальна довжина 6 і має містити 1 великий регістр, 1 нижній регістр, 1 спеціальний символ і 1 цифру")]
        public string Password { get; set; }
		[Required(ErrorMessage = "Повторіть пароль, пітвердження обов'язкове")]
	
		public string PasswordConfirm { get; set; }
        public string? Role { get; set; }
    }
}
