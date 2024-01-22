using Learning.DbContextSetup;
using Microsoft.EntityFrameworkCore;

namespace Sentra.Test
{
    public static class DbSetup
    {
        private static LearningDbContext _context = new LearningDbContext();
        private static bool isAtatched = false;

        public static LearningDbContext AttachDatabase()
        {
            if (!isAtatched)
            {
                try
                {
                    string connectionString = $"Data Source=learning.db;";
                    var options = new DbContextOptionsBuilder<LearningDbContext>()
                        .UseSqlite(connectionString)
                        .Options;
                    _context = new LearningDbContext(options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error attaching database: {ex.Message}");
                }
                isAtatched = true;
                return _context;
            }
            else
            {
                return _context;
            }
        }
    }
}
