using UOWWebApi.DAL.Repository;

namespace UOWWebApi.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestContext _context;

        public UnitOfWork(TestContext context) {
            _context = context;
            Test = new TestRepository(_context);
        }


        public ITestRepository Test { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
