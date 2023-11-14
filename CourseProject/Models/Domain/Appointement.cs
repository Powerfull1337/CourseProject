namespace CourseProject.Models.Domain
{
    public class Appointement
    { 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
		public string UserId { get; set; }  // Додайте це поле
		public string Email { get; set; }
        public string Phone { get; set; }
		public DateTime TimeOfBook { get; set; }
		public DateTime DateOfBook { get; set; }
		public string Description { get; set; }
    }
}
