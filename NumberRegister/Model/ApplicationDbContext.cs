using Microsoft.EntityFrameworkCore;

namespace NumberRegister.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Number> Numbers { get; set; }
    }
}