using Microsoft.EntityFrameworkCore;

namespace Learning.DbContextSetup
{
    public class LearningDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public LearningDbContext(DbContextOptions options) : base(options)
        {
        }

        // You can also include the default constructor for other scenarios
        public LearningDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=learning.db"); // Replace with your connection string
        }
    }
}
