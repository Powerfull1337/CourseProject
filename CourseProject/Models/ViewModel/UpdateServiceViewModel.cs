﻿namespace CourseProject.Models
{
	public class UpdateServiceViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public string? Image { get; set; }
		public string? Description { get; set; }
	}
}
