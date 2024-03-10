using Microsoft.EntityFrameworkCore;

namespace Learning.DbContextSetup
{
    public class TestDbContext : LearningDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
