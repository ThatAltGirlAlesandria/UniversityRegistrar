using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
    public class UniversityRegistrarContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Department> Departments {get; set;}
        public UniversityRegistrarContext(DbContextOptions options) : base(options) { }
    }
}