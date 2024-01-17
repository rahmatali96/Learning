using Learning.DbContextSetup;
using Sentra.Test;

namespace Learning.Test
{
    public class TestClass
    {
        private LearningDbContext _context;
        public TestClass()
        {
            _context = new LearningDbContext();
        }
        [SetUp]
        public async Task SetupAsync()
        {
            _context = await DbSetup.AttachDatabaseAsync();
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(_context.Employees.Count() == 2);
        }
    }
}