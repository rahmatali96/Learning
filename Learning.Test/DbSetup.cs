using Learning.DbContextSetup;
using Microsoft.EntityFrameworkCore;

namespace Sentra.Test
{
    public static class DbSetup
    {
        private static bool isAtatched = false;
        private static TestDbContext _context;

        public static TestDbContext AttachDatabase()
        {
            if (!isAtatched)
            {   
                try
                {
                    string connectionString = $"Data Source=learning.db;";
                    var options = new DbContextOptionsBuilder<TestDbContext>()
                        .UseSqlite(connectionString)
                        .Options;
                    _context = new TestDbContext(options);
                    _context.Tests.Add(new Learning.DbContextSetup.Test()
                    {
                        Name = "test",
                    });
                    _context.SaveChanges();
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
