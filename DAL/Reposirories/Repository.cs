using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using static AutoMapper.Mapper;

namespace DAL.Reposirories
{
    public class Repository<TDal, TOrm> : IRepository<TDal> where TDal : IDalEntity where TOrm : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            CreateMap<TDal, TOrm>();
            CreateMap<TOrm, TDal>();
            this.context = context;
        }

        public void Create(TDal entity)
        {
            context.Set<TOrm>().Add(Map<TDal, TOrm>(entity));
        }

        public void Delete(TDal entity)
        {
            context.Set<TOrm>().Remove(Map<TDal, TOrm>(entity));
        }

        public IEnumerable<TDal> GetAll(Expression<Func<TDal, bool>> func)
        {
            var param = Expression.Parameter(typeof(TOrm));
            var result = new ExpressionModifier<TOrm>(param).Visit(func.Body);
            Expression<Func<TOrm, bool>> lambda = Expression.Lambda<Func<TOrm, bool>>(result, param);
            return context.Set<TOrm>().Where(lambda).Select(orm => Map<TOrm, TDal>(orm));
        }

        public TDal GetFirst(Expression<Func<TDal, bool>> func)
        {
            var param = Expression.Parameter(typeof(TOrm));
            var result = new ExpressionModifier<TOrm>(param).Visit(func.Body);
            Expression<Func<TOrm, bool>> lambda = Expression.Lambda<Func<TOrm, bool>>(result, param);
            return Map<TOrm, TDal>(context.Set<TOrm>().FirstOrDefault(lambda));
        }

        public void Update(TDal entity)
        {
            var orm = Map<TDal, TOrm>(entity);
            context.Set<TOrm>().Attach(orm);
            context.Entry(orm).State = EntityState.Modified;
        }
    }
}
