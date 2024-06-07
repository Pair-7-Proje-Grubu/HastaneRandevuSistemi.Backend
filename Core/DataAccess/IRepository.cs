using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        List<T> GetList(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    }
}
