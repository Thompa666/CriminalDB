using CriminalDB.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CriminalDB.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
            Context.SaveChanges();
        }
    }
}
