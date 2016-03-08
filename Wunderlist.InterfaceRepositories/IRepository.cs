using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.InterfaceRepositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> func);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
