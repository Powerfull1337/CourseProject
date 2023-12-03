namespace CourseProject.Models.Domain
{
	public class Question
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string? Description { get; set; }
	}
}
