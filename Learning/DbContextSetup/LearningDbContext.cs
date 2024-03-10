using Microsoft.EntityFrameworkCore;

namespace Learning.DbContextSetup
{
    public class LearningDbContext : DbContext
    {

        public LearningDbContext(DbContextOptions options) : base(options)
        {
        }

        // You can also include the default constructor for other scenarios
        public LearningDbContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Test> Tests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
