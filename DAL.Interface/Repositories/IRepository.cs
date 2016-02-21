using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interface.Repositories
{
    public interface IRepository<TEntity> where TEntity : IDalEntity
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> func);
        TEntity GetFirst(Expression<Func<TEntity, bool>> func);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
