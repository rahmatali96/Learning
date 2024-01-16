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
        public void Setup()
        {
            _context = DbSetup.AttachDatabase();
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(_context.Employees.Count() == 2);
        }
    }
}