using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class AddAppointmentViewModel
    {
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обов'язковий")]
        public string Phone { get; set; }

		[Required(ErrorMessage = "Послуга обов'язкова")]
		public string ServiceName { get; set; }
		[Required(ErrorMessage = "Час обов'язковий")]
		public string Price { get; set; }
		public DateTime TimeOfBook { get; set; }

		[Required(ErrorMessage = "Дата обов'язкова")]
        public DateTime DateOfBook { get; set; }

        public string Description { get; set; }
    }
}
