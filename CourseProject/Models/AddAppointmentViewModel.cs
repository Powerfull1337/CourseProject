using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class AddAppointmentViewModel
    {
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Прізвище обов'язкове")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обов'язковий")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Дата обов'язкова")]
        public DateTime DateOfBook { get; set; }

        [Required(ErrorMessage = "Дайте нам більше деталей")]
        public string Description { get; set; }
    }
}
