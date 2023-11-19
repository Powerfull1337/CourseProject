namespace CourseProject.Models.Domain
{
    public class Appointement
    { 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
		public string UserId { get; set; }  
		public string Email { get; set; }
        public string Phone { get; set; }
		public string ServiceName { get; set; }
		public string Price { get; set; }
		public DateTime TimeOfBook { get; set; }
		public DateTime DateOfBook { get; set; }
		public string Description { get; set; }
    }
}
