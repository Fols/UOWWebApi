using UOWWebApi.Models;

namespace UOWWebApi.DAL.Repository
{
    public interface ITestRepository:IRepository<TestItem>
    {
        void PutTestItem(TestItem item);
    }
}
