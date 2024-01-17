using Learning.DbContextSetup;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;

namespace Sentra.Test
{
    public static class DbSetup
    {
        private const string ServerName = "localhost\\SQLExpress";
        private static string databaseName = "learning";
        private static LearningDbContext _context = new LearningDbContext();
        private static bool isAtatched = false;

        public static async Task<LearningDbContext> AttachDatabaseAsync()
        {
            if (!isAtatched)
            {
                //string connectionString = @"Server=localhost\\SQLExpress;Database=learning;User=sa;Password=Post@123;";
                string connectionString = "Data Source=learning.db;";

                //string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=learning;User=sa;Password=Post@123;Integrated Security=True;Connect Timeout=120;Encrypt=False;Trust Server Certificate=False";
                //string currentDirectory = Directory.GetCurrentDirectory();
                //string fileName = "learning.mdf";
                //var parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent;
                //string mdfFilePath = Path.Combine(parentDirectory.FullName, fileName);
                //Console.WriteLine(mdfFilePath);
                //ServerConnection serverConnection = new ServerConnection(ServerName);
                //Server server = new Server(serverConnection);
                //Console.WriteLine("connected successfully.");
                try
                {
                    ////server.Databases.Add(new Database { Name = databaseName });
                    //if (server.Databases.Contains(databaseName))
                    //{
                    //    Console.WriteLine("Database exist.");
                    //    server.DetachDatabase(databaseName, false);
                    //}
                    //Console.WriteLine("Database attaching started.");
                    //server.AttachDatabase(databaseName, new StringCollection { mdfFilePath });
                    //Console.WriteLine("Database attached successfully.");

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

                    await _context.SaveChangesAsync();
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
