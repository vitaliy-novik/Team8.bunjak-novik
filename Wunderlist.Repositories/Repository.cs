using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public IEnumerable<T> GetAll(Func<T, bool> func)
        {
            return _context.Set<T>().Where(func).ToList();
        }

        public T GetFirst(Func<T, bool> func)
        {
            return _context.Set<T>().FirstOrDefault(func);
        }

        public void Update(T t)
        {
            _context.Set<T>().Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
