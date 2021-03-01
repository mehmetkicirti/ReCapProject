﻿using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<T, TContext> : IRepositoryBase<T>
        where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    context.Set<T>().ToList() :
                    context.Set<T>().Where(filter).ToList();
            }
        }

        public void Remove(T entity)
        {
            using (var context = new TContext())
            {
                var removedEntity = context.Entry<T>(entity);
                removedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry<T>(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
