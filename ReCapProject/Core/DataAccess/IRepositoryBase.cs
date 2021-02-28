using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IRepositoryBase<T>
        where T: class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
