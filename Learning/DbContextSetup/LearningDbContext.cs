using Microsoft.EntityFrameworkCore;

namespace Learning.DbContextSetup
{
    public class LearningDbContext : DbContext
    {
        public LearningDbContext()
        {
        }

        public LearningDbContext(DbContextOptions<LearningDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
