namespace CourseProject.Models
{
    public class UpdateAppointmentViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
		public DateTime TimeOfBook { get; set; }
		public DateTime DateOfBook { get; set; }
        public string Description { get; set; }
    }
}

