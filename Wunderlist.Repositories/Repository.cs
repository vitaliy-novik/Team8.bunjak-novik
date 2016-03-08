using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> func)
        {
            return await _context.Set<T>().Where(func).ToListAsync();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> func)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(func);
        }

        public void Update(T t)
        {
            _context.Set<T>().Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
