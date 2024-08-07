﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? Get(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = false);
        List<T> GetList(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = false);

    }
}
