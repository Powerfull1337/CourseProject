﻿namespace CourseProject.Models
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
