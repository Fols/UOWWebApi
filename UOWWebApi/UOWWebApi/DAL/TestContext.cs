using Microsoft.EntityFrameworkCore;
using UOWWebApi.Models;

namespace UOWWebApi.DAL
{
    public class TestContext: DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) {

        }

        public DbSet<TestItem> TestItems { get; set; }
    }
}
