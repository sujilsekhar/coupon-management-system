using System.Data.Entity;

namespace Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext c;
        public DbContextFactory()
        {
            c = new Db();
        }

        public DbContext GetContext()
        {
            return c;
        }
    }

    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}