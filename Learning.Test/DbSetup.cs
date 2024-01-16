using Learning.DbContextSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;

namespace Sentra.Test
{
    public static class DbSetup
    {
        private const string ServerName = "Learn\\Pro";
        private static string databaseName = "learning";
        private static LearningDbContext _context;
        private static bool isAtatched = false;

        public static LearningDbContext AttachDatabase()
        {
            if (!isAtatched)
            {
                string connectionString = "Server=Learn\\Pro;learning=Lear;User Id=sa;Password=Post@123;";

                //string connectionString = "Data Source=Learn\\SQLExpress;Initial Catalog=learning;User Id=sa;Password=Post@123;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False";
                string currentDirectory = Directory.GetCurrentDirectory();
                string fileName = "learning.mdf";
                var parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent;
                string mdfFilePath = Path.Combine(parentDirectory.FullName, fileName);
                Console.WriteLine(mdfFilePath);
                ServerConnection serverConnection = new ServerConnection(ServerName);
                Server server = new Server(serverConnection);
                try
                {
                    if (server.Databases.Contains(databaseName))
                    {   
                        server.DetachDatabase(databaseName, false);
                    }
                    server.AttachDatabase(databaseName, new StringCollection { mdfFilePath });
                    Console.WriteLine("Database attached successfully.");
                    var options = new DbContextOptionsBuilder<LearningDbContext>()
                        .UseSqlServer(connectionString)
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
