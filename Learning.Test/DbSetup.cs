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
                string connectionString = "Data Source=learning.db;";
                try
                {
                    var options = new DbContextOptionsBuilder<LearningDbContext>()
                        .UseSqlite(connectionString)
                        .Options;

                    using var _context = new LearningDbContext(options);
                    _context.Database.EnsureDeleted(); // Ensure the database is created

                    _context.Database.EnsureCreated(); // Ensure the database is created

                    _context.Employees.Add(new Employee
                    {
                        Name = "Test",
                    });

                    _context.Employees.Add(new Employee
                    {
                        Name = "Test1",
                    });

                    _context.SaveChanges();
                    Console.WriteLine(_context.Employees.Count());
                    Console.WriteLine("Employees added to the database.");
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
