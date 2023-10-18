using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace CourseProject.Data
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Appointement> Appointements { get; set; }
    }
}
