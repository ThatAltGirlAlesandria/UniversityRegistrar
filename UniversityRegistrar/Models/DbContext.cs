using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
    public class UniversityRegistrarContext : DbContext
    {

        public UniversityRegistrarContext(DbContextOptions options) : base(options) { }
    }
}