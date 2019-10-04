using UOWWebApi.Models;

namespace UOWWebApi.DAL.Repository
{
    public class TestRepository: Repository<TestItem>, ITestRepository
    {
        public TestRepository(TestContext context) : base(context) { }

        public TestContext TestContext { get { return _context as TestContext; } }

        public void PutTestItem(TestItem item)
        {
            TestContext.Set<TestItem>().Update(item);
        }
        
    }
}
