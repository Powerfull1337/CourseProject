using CourseProject.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CourseProject.Data
{
    public class CRUDContext : IdentityDbContext<ApplicationUser>
    {
        public CRUDContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Appointement> Appointements { get; set; }
        public DbSet<Employee> Employees { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Service> Services { get; set; }

	}
}
