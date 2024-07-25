using Learning.DbContextSetup;
using Sentra.Test;

namespace Learning.Test
{
    public class TestClass
    {
        private TestDbContext _context;
        public TestClass()
        {
        }
        [SetUp]
        public void Setup()
        {
            _context = DbSetup.AttachDatabase();
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(_context.Employees.Count());
            Assert.IsTrue(_context.Employees.Count() == 2);
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine(_context.Tests.Count());
            Assert.IsTrue(_context.Tests.Count() == 1);
        }
    }
}