namespace CourseProject.Models.ViewModel
{
	public class AppointmentsViewModel
	{
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBook { get; set; }
		public string TimeOfBook { get; set; }
		public string ServiceName { get; set; }
		public string Price { get; set; }
		public string Description { get; set; }
		public AddAppointmentViewModel AddAppointmentModel { get; set; }
		public List<Domain.Service> Services { get; set; }
	}
}
