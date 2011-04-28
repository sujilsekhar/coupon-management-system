using System.Collections.Generic;
using System.Data.Entity;
using Core.Model;
using Core.Repository;

namespace Data
{
    public class ReadRepo<T> : IReadRepo<T> where T : Entity
    {
        protected readonly DbContext c;

        public ReadRepo(IDbContextFactory f)
        {
            c = f.GetContext();
        }

        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return c.Set<T>();
        }
    }
}