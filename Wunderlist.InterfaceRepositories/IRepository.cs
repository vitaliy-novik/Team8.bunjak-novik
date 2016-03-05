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
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> func);
        TEntity GetFirst(Expression<Func<TEntity, bool>> func);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
